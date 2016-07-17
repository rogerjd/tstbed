using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

/*
    Arrays are fixed size, which means you can't add more elements than the 
    number allocated at creation time, if you need a auto sizing collection you 
    could use List<T> or an ArrayList
*/
    static class Array
    {
        static int[] ary = { 1, 2, 3, 4, 5 };

        public static void Test()
        {
            Console.WriteLine("Array ****");
            Contains();
            ModifyInMethod();
        }

        private static void ModifyInMethod()
        {
            Console.WriteLine("Modify in Method **");
            int[] n = { 7, 8, 9 };
            method1(n);
            Console.WriteLine(string.Join(" ",  n));
        }

        static void method1(int[] m)
        {
            m[0] = 2;
        }

        private static void Contains()
        {
            Console.WriteLine("Contains **");
            bool b = ary.Contains(3);
            Console.WriteLine(b);


            b = ary.Contains(99);
            Console.WriteLine(b);
        }
    }
}
