using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Numbers
    {
        static internal void Test()
        {
            Utils.WriteTopic("Numbers");

            Round();
        }

        private static void Round()
        {
            Utils.WriteSubTopic("Round");

            //real to int
            float s = 1.89F;
            int n = Convert.ToInt32(s);
            Utils.WriteDetailLine(n.ToString());

            decimal d = 12.789M;
            d = decimal.Round(d, 2);
            Utils.WriteDetailLine(d.ToString());

        }
    }
}
