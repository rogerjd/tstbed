using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Loop
    {
        static public void Test()
        {
            ForTst();
        }

        private static void ForTst()
        {
            Console.WriteLine("for test");
            int[] n = { 1, 2, 3, 4, 5 };
            for (int i = 0; i < n.Length; i++)
            {
                Console.WriteLine("Value at index {0} is {1}", i, n[i]);
            }
        }
    }
}
