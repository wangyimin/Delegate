using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checks.Utils
{
    class StringUtils
    {
        public static string Array2String(object[] obj)
        {
            string r = "[";

            foreach (object o in obj)
                r = r + o + ",";

            return r.Substring(0, r.Length - 1) + "]";
        }
    }
}
