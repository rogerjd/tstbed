using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class StringBuilderTst
    {

        internal static void Test()
        {
            Utils.WriteTopic("String Builder");

            //Append: one big line
            //AppendLine: adds \n\r, so adds a line, when prtd

            StringBuilder sb = new StringBuilder("abc", 100); //pay attention to ctor overloads

            sb.Append("def");
            sb.AppendLine("ghi"); //ref: 2 chars, \n\r
            sb.AppendFormat("{0}", "jkl");

            sb.Insert(0, "0");

            char c = sb[0];

            //clear empty
            //  make new one(will release memory), or set Length = 0

            Utils.WriteDetailLine(string.Format("{0} {1}", sb.ToString(), sb.Length));
        }
    }
}
