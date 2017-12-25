using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    //see ExtensionMethods for examples

    /*
     * 1 - can call func  p => MyFunc(p)
     * 2 - can have multiple params (if Func<> allows), enclose in parentheses
     *      (prod, count) => prod.Price >= 20  && count > 0
     * 3 - can have multiple statements, use braces and return
     *      p => {
     *          ....
     *          ....
     *          return;
     *      }
     */
    static class Lambda
    {
        public static void Test()
        {
            PassAsParam();
        }

        private static void PassAsParam()
        {
            Write(() => "message: " + GetMsgTxt());
        }

        private static string GetMsgTxt()
        {
            return "msg test";
        }

        //once the func get here, it can decide (bool) whether it gets executed or not
        //  perhaps, conditional compile, but at runtime, and dont also want params to exec
        static void Write(Func<string> msg)
        {
            if (true) //exec func and params
            {
                Utils.WriteDetailLine(msg());
            }
        }
    }
}
