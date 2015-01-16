using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.SQLite;

namespace SD2Blog
{
    class Pokemon
    {
        public string Key { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Nature { get; set; }
        public string Item { get; set; }
        public string Ability { get; set; }
        public bool Shiny { get; set; }
        public string Gender { get; set; }
        public int Happiness { get; set; }
        public string NickName { get; set; }


        public Dictionary<string, int> EVs { get; set; }
        public Dictionary<string, int> IVs { get; set; }
        public Dictionary<string, int> Stats { get; set; }
        public Dictionary<string, int> BaseStats { get; set; }

        public List<string> Moves { get; set; }

        private int moveCounter;

        public Pokemon()
        {
            moveCounter = 0;
            Name = "None";
            Key = "none";
            Id = "none";
            Nature = "None";
            Item = "None";
            Ability = "None";
            NickName = "None";
            Level = 0;
            Shiny = false;
            Happiness = 0;

            IVs = new Dictionary<string, int>() 
            {
                {"HP", 31 }, {"Atk", 31 }, {"Def", 31 },
                {"SpA", 31 }, {"SpD", 31 }, {"Spe", 31 }
            };
            EVs = new Dictionary<string, int>()
            {
                {"HP", 0 }, {"Atk", 0 }, {"Def", 0 },
                {"SpA", 0 }, {"SpD", 0 }, {"Spe", 0 }
            };
            Stats = new Dictionary<string, int>()
            {
                {"HP", 0 }, {"Atk", 0 }, {"Def", 0 },
                {"SpA", 0 }, {"SpD", 0 }, {"Spe", 0 }
            };
            BaseStats = new Dictionary<string, int>();
            
            Moves = new List<string>()
            {
                "None", "None", "None", "None"
            };


        }


        public void addMove(string move)
        {
            Moves[moveCounter++] = move;
        }
        public void calcStats()
        {
            Name = Name.Trim();
            Id = Util.toId(Name);
            Key = Util.toKey(Name);

            SQLiteHelper sql = new SQLiteHelper();
            BaseStats = sql.getBaseStats(Key);

            Dictionary<string, double> natureMod = sql.getNatureMod(Nature);
            string[] statsName = { "HP", "Atk", "Def", "SpA", "SpD", "Spe" };

            foreach (string stat in statsName)
            {
                // {(種族値×2＋個体値＋努力値/4)×Lv/100}＋10＋Lv
                if (stat == "HP")
                {
                    Stats[stat] = BaseStats[stat] * 2 + IVs[stat] + EVs[stat] / 4;
                    Stats[stat] = Stats[stat] * Level / 100;
                    Stats[stat] = Stats[stat] + 10 + Level;
                }
                else
                {
                    //[{(種族値×2＋個体値＋努力値/4)×Lv/100}＋5]×性格補正(1.1、1.0、0.9)
                    Stats[stat] = BaseStats[stat] * 2 + IVs[stat] + EVs[stat] / 4;
                    Stats[stat] = Stats[stat] * Level / 100;
                    Stats[stat] = Stats[stat] + 5;
                    Stats[stat] = Convert.ToInt32(Math.Floor(Stats[stat] * natureMod[stat]));
                }
            }
        }

    }
}
