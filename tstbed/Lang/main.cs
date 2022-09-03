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
            switch (Utils.GetCmdArg(args, 1))
            {
                case "using":
                    UsingTest.Test(args);
                    break;
                default:
                    Utils.WriteDetailLine("Arg 1 not found");
                    break;
            }
        }
    }
}
