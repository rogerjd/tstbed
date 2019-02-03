using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Lang
{
    static class Main
    {
        public static void Test(string[] args)
        {
            if (args.Length < 1)
            {
                return;
            }
            switch (args[1])
            {
                case "using":
                    UsingTest.Test(args);
                    break;
                default:
                    break;
            }
        }
    }
}
