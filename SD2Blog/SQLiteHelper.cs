using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace SD2Blog
{
    class SQLiteHelper
    {
        string dbConnectionName;

        public SQLiteHelper()
        {
            this.dbConnectionName = "Data Source=pokemon.db";
        }


        public Dictionary<string, int> getBaseStats(string name)
        {
            string key = Util.toKey(name);
            string[] stats = { "HP", "Atk", "Def", "SpA", "SpD", "Spe" };
            Dictionary<string, int> baseStats = new Dictionary<string, int>();
            using (SQLiteConnection cn = new SQLiteConnection(dbConnectionName))
            {
                cn.Open();
                SQLiteCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT * FROM pokedex where key = '" + key + "';";

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            baseStats[stats[i]] = Convert.ToInt32(reader[stats[i].ToLower()].ToString());
                        }
                    }
                }
            }

            return baseStats;
        }



        public Dictionary<string, double> getNatureMod(string natureName)
        {
            string key = Util.toKey(natureName);
            Dictionary<string, double> natureMod = new Dictionary<string, double>()
            {
                {"HP",1.0},
                {"Atk",1.0},
                {"Def",1.0},
                {"SpA",1.0},
                {"SpD",1.0},
                {"Spe",1.0},
            };
            using (SQLiteConnection cn = new SQLiteConnection(dbConnectionName))
            {
                cn.Open();
                SQLiteCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT * FROM natures where key = '" + key + "';";

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        natureMod[reader["plus"].ToString()] = 1.1;
                        natureMod[reader["minus"].ToString()] = 0.9;
                    }
                }
            }

            return natureMod;
        }

        public string toJapanese(string name)
        {
            string key = Util.toKey(name);
            using (SQLiteConnection cn = new SQLiteConnection(dbConnectionName))
            {
                cn.Open();
                SQLiteCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT * FROM dictionary where key = '" + key + "';";

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        name = reader["japanese_name"].ToString();
                    }
                }
            }

            return name;
        }

        public List<string[]> loadDictionary()
        {
            List<string[]> datas = new List<string[]>();
            using (SQLiteConnection cn = new SQLiteConnection(dbConnectionName))
            {
                cn.Open();
                SQLiteCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT * FROM dictionary;";

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string key = reader["key"].ToString();
                        string japanese_name = reader["japanese_name"].ToString();
                        string english_name = reader["english_name"].ToString();

                        datas.Add(new string[] { key, japanese_name, english_name });

                    }
                }
            }

            return datas;
        }

        public int getNum(string name)
        {
            int num = -1;
            string key = Util.toKey(name);
            using (SQLiteConnection cn = new SQLiteConnection(dbConnectionName))
            {
                cn.Open();
                SQLiteCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT * FROM pokedex where key = '" + key + "';";

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        num = Convert.ToInt32(reader["num"]);
                    }
                }
            }

            return num;
        }

        public void deleteDictionary()
        {
            using (SQLiteConnection cn = new SQLiteConnection(dbConnectionName))
            {
                cn.Open();
                SQLiteCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM dictionary;";
                cmd.ExecuteNonQuery();
            }
        }
        public void saveDictionary(List<string[]> datas)
        {
            using (SQLiteConnection cn = new SQLiteConnection(dbConnectionName))
            {
                cn.Open();
                using (var transaction = cn.BeginTransaction())
                {
                    foreach (string[] data in datas)
                    {
                        string commandText = "INSERT INTO dictionary values(";
                        commandText += String.Format("\"{0}\", \"{1}\", \"{2}\"", data[0], data[1], data[2]);
                        commandText += ");";
                        using (var command = new SQLiteCommand(commandText, cn))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
            }
        }

    }
}
