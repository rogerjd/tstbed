using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //Debug: only for debug builds. Trace: debug and release
    static class TraceDebug
    {
        public static void Test()
        {
            Debug.Write("debug");

            int x = 2, y = 3;
            Debug.WriteLine("");
            Debug.WriteLineIf(x < y, "x less than y");
        }
    }
}
