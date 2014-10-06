using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace SD2Blog
{
    class SDParsar
    {


        private string[] sdData;

        public void setSDData(string sdData)
        {
            this.sdData = sdData.Split(new Char[] { '\n' });
        }


        public Pokemon parse(ref int offset)
        {
            Pokemon pokemon = new Pokemon();

            for (int i = offset; i < sdData.Length; i++)
            {
                string line = sdData[i];
                if (offset == i)
                {

                    if (line.IndexOf("@") != -1)
                    {
                        string[] tmp = line.Split(new char[] { '@' });
                        pokemon.Item = tmp[1].Trim();
                        line = tmp[0];
                    }

                    line = line.Trim();

                    int genderIdx = Math.Max(line.IndexOf("(M)"), line.IndexOf("(F)"));
                    if (genderIdx != -1)
                    {
                        pokemon.Gender = line.Substring(genderIdx + 1, 1);
                        line = line.Substring(0, line.Length - 4);
                    }

                    string[] before = line.Split(new char[] { ' ' });

                    if (before.Length == 1)
                    {
                        pokemon.Name = before[0];
                    }
                    else
                    {
                        string name = before[before.Length - 1];
                        string nickName = "";

                        for (int j = 0; j < before.Length - 1; j++)
                        {
                            nickName += before[j] + " ";
                        }

                        pokemon.Name = name.Substring(1, name.Length - 2);
                        pokemon.NickName = nickName.Trim();

                    }

                }
                else if (line.IndexOf("Trait: ") != -1)
                {
                    pokemon.Ability = line.Substring(7);
                }
                else if (line.IndexOf("Ability: ") != -1)
                {
                    pokemon.Ability = line.Substring(9);
                }
                else if (line == "Shiny: Yes")
                {
                    pokemon.Shiny = true;
                }
                else if (line.IndexOf("Level: ") != -1)
                {
                    pokemon.Level = Convert.ToInt32(line.Substring(7));
                }
                else if (line.IndexOf("Happiness: ") != -1)
                {
                    pokemon.Happiness = Convert.ToInt32(line.Substring(9));
                }
                else if (line.IndexOf("EVs: ") != -1)
                {
                    string[] evData = line.Substring(5).Split(new Char[] { '/' });
                    Dictionary<string, int> evs = new Dictionary<string, int>()
                    {
                        {"HP", 0 },
                        {"Atk", 0 },
                        {"Def", 0 },
                        {"SpA", 0 },
                        {"SpD", 0 },
                        {"Spe", 0 }
                    };

                    foreach (string ev in evData)
                    {
                        string[] t = ev.Trim().Split(new Char[] { ' ' });
                        evs[t[1].Trim()] = Convert.ToInt32(t[0]);
                    }

                    pokemon.EVs = evs;
                }
                else if (line.IndexOf("IVs: ") != -1)
                {
                    string[] ivData = line.Substring(5).Split(new Char[] { '/' });
                    Dictionary<string, int> ivs = new Dictionary<string, int>()
                    {
                        {"HP", 31 },
                        {"Atk", 31 },
                        {"Def", 31 },
                        {"SpA", 31 },
                        {"SpD", 31 },
                        {"Spe", 31 }
                    };

                    foreach (string iv in ivData)
                    {
                        string[] t = iv.Trim().Split(new Char[] { ' ' });
                        ivs[t[1].Trim()] = Convert.ToInt32(t[0]);
                    }

                    pokemon.IVs = ivs;
                }
                else if (line.IndexOf(" Nature") != -1)
                {
                    int idx = line.IndexOf(" Nature");
                    pokemon.Nature = line.Substring(0, idx);
                }
                else if (line == "")
                {
                    offset = i + 1;
                    break;
                }
                else if (line[0] == '-')
                {
                    pokemon.addMove(line.Substring(2));
                } // end if
            } // end foreach

            return pokemon;
        }

        public SDParsar(string sdData)
        {
            this.sdData = sdData.Split(new Char[] { '\n' });

        }

    }
}
