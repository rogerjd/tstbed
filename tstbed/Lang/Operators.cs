using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Lang
{
    static class Operators
    {
        public static void Test()
        {
            Utils.WriteTopic("Operators");

            NullCoalesce(); //??
        }

        //??
        private static void NullCoalesce()
        {
            Utils.WriteSubTopic("Null Coalesce ??");
            int? n = null;
            int i = n ?? 3;
            Utils.WriteDetailLine(i.ToString());
            n = 2;
            i = n ?? -1;
            Utils.WriteDetailLine(i.ToString());
        }
    }
}
