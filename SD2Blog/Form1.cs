using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Text.RegularExpressions;


namespace SD2Blog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        delegate string LangConvert(string name);
        private void buttonConvert_Click(object sender, EventArgs e)
        {
            SDParsar sdparsar = new SDParsar(textBoxIn.Text.Replace("\r\n", "\n"));
            SQLiteHelper sql = new SQLiteHelper();
            Pokemon[] pokemon = new Pokemon[6];


            LangConvert langConvert = new LangConvert(sql.toJapanese);

            int offset = 0;
            for (int i = 0; i < pokemon.Length; i++)
            {
                pokemon[i] = sdparsar.parse(ref offset);
                pokemon[i].calcStats();
                textBoxOut.Text += pokemon[i].Id + "\r\n";
            }

            string template = textBoxTemplate.Text;

            string[] member = {"Id", "Name","Key", "Item", "Ability","Move", "Level",
                                  "Nature" ,"Stats","BaseStats", "EVs", "IVs", "NickName", "Num" };

            for (int i = 0; i < pokemon.Length; i++)
            {
                foreach (string s in member)
                {
                    string pattern = String.Format("Pokemon{0}.{1}", i + 1, s);
                    if (s == "Id")
                    {
                        template = template.Replace(pattern, pokemon[i].Id);
                    }
                    else if (s == "Name")
                    {
                        template = template.Replace(pattern, langConvert(pokemon[i].Name));
                    }
                    else if (s == "Key")
                    {
                        template = template.Replace(pattern, pokemon[i].Key);
                    }
                    else if (s == "Ability")
                    {
                        template = template.Replace(pattern, langConvert(pokemon[i].Ability));
                    }
                    else if (s == "Item")
                    {
                        template = template.Replace(pattern, langConvert(pokemon[i].Item));
                    }
                    else if (s == "Move")
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            string t = pattern + String.Format("{0}", j + 1);
                            template = template.Replace(t, langConvert(pokemon[i].Moves[j]));
                        }
                    }
                    else if (s == "Level")
                    {
                        string t = String.Format("{0}", pokemon[i].Level);
                        template = template.Replace(pattern, t);
                    }
                    else if (s == "Nature")
                    {
                        template = template.Replace(pattern, langConvert(pokemon[i].Nature));
                    }
                    else if (s == "Stats")
                    {
                        var stats = pokemon[i].Stats;
                        string t = "";
                        foreach (var stat in stats)
                        {
                            t += stat.Value.ToString() + "-";
                        }
                        t = t.Substring(0, t.Length - 1);

                        template = template.Replace(pattern, t);

                    }
                    else if (s == "BaseStats")
                    {

                        var baseStats = pokemon[i].BaseStats;
                        string t = "";
                        foreach (var baseStat in baseStats)
                        {
                            t += baseStat.Value.ToString() + "-";
                        }
                        t = t.Substring(0, t.Length - 1);

                        template = template.Replace(pattern, t);
                    }
                    else if (s == "EVs")
                    {

                        var EVs = pokemon[i].EVs;
                        string t = "";
                        foreach (var ev in EVs)
                        {
                            t += ev.Value.ToString() + "-";
                        }
                        t = t.Substring(0, t.Length - 1);

                        template = template.Replace(pattern, t);
                    }

                    else if (s == "IVs")
                    {

                        var IVs = pokemon[i].IVs;
                        string t = "";
                        foreach (var iv in IVs)
                        {
                            t += iv.Value.ToString() + "-";
                        }
                        t = t.Substring(0, t.Length - 1);

                        template = template.Replace(pattern, t);
                    }
                    else if (s == "NickName")
                    {
                        template = template.Replace(pattern, langConvert(pokemon[i].NickName));
                    }
                    else if (s == "Num")
                    {
                        template = template.Replace(pattern, pokemon[i].Num.ToString());
                    }

                }
            }

            textBoxOut.Text = template;

        }



        private void textBoxIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.A & e.Control)
            {
                textBoxIn.SelectAll();
            }
        }

        private void textBoxOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.A & e.Control)
            {
                textBoxOut.SelectAll();
            }
        }

        private void textBoxTemplate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.A & e.Control)
            {
                textBoxTemplate.SelectAll();
            }
        }

        private void loadTemplateList()
        {
            string[] files = 
                System.IO.Directory.GetFiles(
                "./template", "*", System.IO.SearchOption.TopDirectoryOnly);

            string expression = @"template\\(.*)";
            Regex reg = new Regex(expression);
            for (int i = 0; i < files.Length; i++)
            {
                Match match = reg.Match(files[i]);
                files[i] = match.Groups[1].Value;
            }
            cmbTemplateList.Items.AddRange(files);

            cmbTemplateList.Text = cmbTemplateList.Items[0].ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var fileName = cmbTemplateList.Text.ToString();
            StreamWriter writer = new StreamWriter("./template/" + fileName, false, Encoding.GetEncoding("UTF-8"));

            writer.WriteLine(textBoxTemplate.Text);

            writer.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            loadTemplateList();


            SQLiteHelper sql = new SQLiteHelper();

            List<string[]> datas = sql.loadDictionary();
            DataGridViewRow[] rows = new DataGridViewRow[datas.Count];

            for (int i = 0; i < datas.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.SetValues(datas[i]);
                rows[i] = row;
            }

            dataGridView1.Rows.AddRange(rows);

        }

        private void buttonSaveDictionary_Click(object sender, EventArgs e)
        {
            SQLiteHelper sql = new SQLiteHelper();
            List<string[]> datas = new List<string[]>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["key"].Value != null)
                {
                    datas.Add(new string[] 
                    { 
                        row.Cells["key"].Value.ToString(),
                        row.Cells["englishName"].Value.ToString(),
                        row.Cells["japaneseName"].Value.ToString(),
                    });
                }
            }
            sql.deleteDictionary();
            sql.saveDictionary(datas);

        }

        private void cmbTemplateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fileName = cmbTemplateList.Text.ToString();
            StreamReader reader = new StreamReader("./template/" + fileName, Encoding.GetEncoding("UTF-8"));

            textBoxTemplate.Text = reader.ReadToEnd();

            reader.Close();
        }
    }
}
