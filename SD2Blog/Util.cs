using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SD2Blog
{
    class Util
    {
        public static string toKey(string s)
        {
            Regex reg = new Regex("[^a-z0-9]+");
            return reg.Replace(s.Trim().ToLower(), "");
        }
        public static string toId(string s)
        {
            return s.Trim().ToLower();
        }

    }
}
