using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Lang
{
    class Func__local
    {
        void Main()
        {
            void tst()
            {

            }

            tst();

            int totalLength(string s1, string s2) => s1.Length + s2.Length; //local func w/lambda
                                                                            //ok  above    Func<string, string, int> totalLength = (s1, s2) => s1.Length + s2.Length;
            int total = totalLength("abc", "defg");
        }
    }
}
