using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{

    /*
        Arrays are fixed size, which means you can't add more elements than the 
        number allocated at creation time, if you need a auto sizing collection you 
        could use List<T> or an ArrayList

        int[] n   can assign another int[] to, regardless of size

        it is ref type (so can modify orig in a called method)
    */
    static class ArrayTst
    {
        static int[] ary = { 1, 2, 3, 4, 5 };
        static bool[] ary2 = new bool[10];

        static string[,] md = new string[2, 3] { { "", "", "" }, { "", "", "" } }; //2 dimensional array

        public static void Test()
        {
            Utils.WriteTopic("Array");

            Create();

            Contains();
            Declare();
            ModifyMethodParam();

            Clone(); //shallow. returns new array
            Copy();  //shallow. copy to existing array, with an index(start pos)

            SortIt();

            FileReadAllLines();

            DefaultValues();

            EnumerateArray();

            Length();
        }

        private static void Declare()
        {
            //can declare an array in a class or method (probably same for structure)

            int[] n = new int[] { 1, 3, 6 };
        }

        private static void Length()
        {
            Utils.WriteSubTopic("Create Array");
            var a = new int[] { }; //if {} present, then must match size [3]
            Utils.WriteDetailLine(a.Length.ToString());
        }

        private static void Create()
        {
            Utils.WriteSubTopic("Create Array");

            //must have size or initializer (can have both, but must match)
            //array initializer {}
            var a = new int[3];

            a = new int[3] { 1, 2, 3 }; //if {} present, then must match size [3]

            a = new int[] { 1, 2, 3 }; //size and init in initializer

            a = new int[] { }; //if {} present, then must match size [3]

            //err: a = new int[]; //must have size or initializer
        }

        private static void EnumerateArray()
        {
            Utils.WriteSubTopic("Enumerate Array");

            int[] scores = new int[] { 97, 92, 81, 60 };

            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            foreach (int i in scoreQuery)
            {
                Utils.WriteDetailLine(i + " ");
            }
        }

        private static void DefaultValues()
        {
            Utils.WriteSubTopic("Default Values");

            var n = default(bool); //bool is false
            if (n)
            {
                Utils.WriteDetailLine("it's true, should be false");
            }

            foreach (var b in ary2)
            {
                if (b)
                {
                    throw new Exception("should be false, found true");
                }
            }
            Utils.WriteDetailLine("all false");
        }

        private static void FileReadAllLines()
        {
            //StringList LoadFromFile ReadFromFile
            Utils.WriteSubTopic("Read All Lines");
            string fn = Environment.CurrentDirectory + @"\tst2.txt";
            string[] lns = File.ReadAllLines(fn);  //throws: FileNotFoundException

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
            Utils.WriteSubTopic("  copy ****");
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
            Utils.WriteSubTopic("Modify in Method **");
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
            Utils.WriteSubTopic("Contains **");
            bool b = ary.Contains(3);
            Console.WriteLine(b);

            b = ary.Contains(99);
            Console.WriteLine(b);
        }
    }
}
