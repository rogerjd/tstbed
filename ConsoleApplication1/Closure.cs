using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Closure
    {
        public static void Test()
        {
            Utils.WriteTopic("Closure");
            var f = GetAFunc();
            var n = f(4);
            Utils.WriteDetailLine(n.ToString());  //6
            n = f(5);
            Utils.WriteDetailLine(n.ToString()); //8
        }

        private static Func<int, int> GetAFunc()
        {
            Utils.WriteTopic("Get a func");

            int n = 1;

            Func<int, int> f = delegate (int x)
            {
                n += 1;
                return n + x;
            };

            return f;
        }
    }
}
