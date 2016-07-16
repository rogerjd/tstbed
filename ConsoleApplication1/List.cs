using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class List
    {
        static List<string> l = new List<string> { "a", "b", "c" };

        public static void Test()
        {
            Console.WriteLine("List ****");
            Count();
            Sort();
            Foreach();
            Modify();
            Indexer();
            Find();
        }

        private static void Find()
        {
            Console.WriteLine("Find **");
            //            l.Find
            Console.WriteLine(l.Contains("a"));
            Console.WriteLine(l.Contains("z"));
        }

        private static void Indexer()
        {
            Console.WriteLine("Indexer **");

            Console.WriteLine(l[0]);
            l[0] = "new";
            Console.WriteLine(l[0]);
        }

        private static void Modify()
        {
            Console.WriteLine("Modify **");

            //ref: one at a time
            Count();
            l.Add("xyz");
            var b = l.Remove("xyz");
            Count();
            Console.WriteLine(b);

            //ref: many
            l.AddRange(new List<string> { "1", "2", "3" });
            Count();

            l.RemoveRange(l.Count() - 3, 3);
            Count();
        }

        private static void Foreach()
        {
            Console.WriteLine("Foreach **");

            foreach (System.String s in l)
            {
                Console.WriteLine(s);

            }
        }

        private static void Sort()
        {
            Console.WriteLine("Sort **");

            l.Sort();
            Console.WriteLine(string.Join(" ", l));

            l.Reverse();
            Console.WriteLine(string.Join(" ", l));
        }

        private static void Count()
        {
            Console.WriteLine("Count **");
            int n = l.Count();
            Console.WriteLine(n);
        }
    }
}
