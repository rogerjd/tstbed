using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApplication1
{
    static class GCTst
    {
        public static void Test()
        {
            MemoryTest();
        }

        private static void MemoryTest()
        {
            long x = GC.GetTotalMemory(true);

            /*
                        Timer t = new Timer(1000);
                        x = GC.GetTotalMemory(true);
                        t.Dispose();
                        x = GC.GetTotalMemory(true);
            */

            StreamReader sr = new StreamReader(@"c:\users\roger\test.txt");
            x = GC.GetTotalMemory(true);
            sr.Dispose();
            x = GC.GetTotalMemory(true);
        }
    }
}
