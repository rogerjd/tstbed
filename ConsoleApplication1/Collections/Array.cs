﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    /*
        Arrays are fixed size, which means you can't add more elements than the 
        number allocated at creation time, if you need a auto sizing collection you 
        could use List<T> or an ArrayList

        int[] n   can assign another int[] to, regardless of size

        it is ref type (so can modify orig in a called method)
    */
    static class Array
    {
        static int[] ary = { 1, 2, 3, 4, 5 };

        public static void Test()
        {
            Utils.WriteTopic("Array");
            Contains();
            ModifyMethodParam();

            Clone(); //shallow. returns new array
            Copy();  //shallow. copy to existing array, with an index(start pos)

            SortIt();

            FileReadAllLines();
        }

        private static void FileReadAllLines()
        {
            Utils.WriteSubTopic("Read All Lines");
            string fn = Environment.CurrentDirectory + @"\tst2.txt";
            string[] lns = File.ReadAllLines(fn);

            //List<string> l = new List<string>(lns);
            //lns.ToList();
        }

        //ref: see List (there are also Linq methods)
        private static void SortIt()
        {
            Utils.WriteSubTopic("Sort");

            int[] a = (int[])ary.Clone();

            System.Array.Sort(a);
            Console.WriteLine("    " + string.Join(" ", a));

            System.Array.Reverse(a);
            Console.WriteLine("    " + string.Join(" ", a));

            //sort by odd then even, but not within
            int[] numbers = { 1, 4, 5, 2, 3 };
            System.Array.Sort(numbers, (x, y) => x % 2 == y % 2 ? 0 : x % 2 == 1 ? -1 : 1);
            Utils.WriteDetailLine(string.Join(" ", numbers));
        }

        //shallow
        //AgrumentException: if number of elements to copy is greater than that contained
        // in the source array
        private static void Copy()
        {
            Console.WriteLine("  copy ****");
            int[] b = new int[5];


            Console.WriteLine("    " + string.Join(" ", b));
            System.Array.Copy(ary, b, 5);
            Console.WriteLine("    " + string.Join(" ", b));
        }

        //shallow
        private static void Clone()
        {
        }

        private static void ModifyMethodParam()
        {
            Console.WriteLine("Modify in Method **");
            int[] n = { 7, 8, 9 };
            method1(n);
            Console.WriteLine(string.Join(" ", n));

            int[] m = { 1, 2, 3, 4, 5, 6, 7 };
            method1(m);
        }

        static void method1(int[] m)
        {
            m[0] = 2; //ok
            int len = m.Length;
            // m[99] = 4; IndexOutOfRangeException
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
