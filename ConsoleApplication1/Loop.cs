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
            WhileTst();
            DoTst();
            foreachTst() ;
        }

        private static void foreachTst()
        {
            //each x (iteration), is a new/different storage location (immutable) so
            //can capture the var in a closure
            foreach (var x in Enumerable.Range(1, 10))
            {
                //x += 1;  error

            }
        }

        private static void DoTst()
        {
            int n = 0;
            do
            {
                Console.WriteLine("Do: {0}", n);
                n++;
            } while (n < 5);
        }

        private static void WhileTst()
        {
            int n = 0;
            while (n < 5)
            {
                Console.WriteLine("While: {0}", n);
                n++;
            }
        }

        private static void ForTst()
        {
            Console.WriteLine("for test");
            int[] n = { 1, 2, 3, 4, 5 };
            { // ref: as if braces around 
                for (int i = 0; i < n.Length; i++)
                {
                    Console.WriteLine("Value at index {0} is {1}", i, n[i]);
                }
            }

            int z; //var can be outside of for
            for (z = 0; z < 4; z++)
            {

            }

            //it is as if i is declared outside, there is only 1 storage location
            for (int i = 0; i < 0; i++)
            {
                Console.WriteLine("This should not execute");
            }
        }
    }
}
