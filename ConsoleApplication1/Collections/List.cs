using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Collections
{
    static class List
    {
        static List<string> l = new List<string> { "z", "a", "b", "c" };

        public static void Test()
        {
            Utils.WriteTopic("List");
            Count();
            Sort();
            Foreach();
            Modify();
            Indexer();
            Find();
            Dups();
            RemoveAt();
        }

        //bug
        private static void RemoveAt()
        {
            List<int> l = new List<int> {1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < l.Count - 1; i++)
            {
                l.RemoveAt(i);
            }
        }

        private static void Dups()
        {
            //must do yourself
            /*
            public static bool AreAnyDuplicates<T>(this IEnumerable<T> list)
            {
                var hashset = new HashSet<T>();
                return list.Any(e => !hashset.Add(e));
            }
            */
        }

        private static void Find()
        {
            Utils.WriteSubTopic("Find");
            Console.WriteLine(l.Contains("z"));

            //ref: predicate
            //      return is not bool, but the item
            Console.WriteLine(l.Find(List.finder));
            string res = l.Find(s => { return s == "a"; });
            Console.WriteLine(res);
            res = "wqwq";
            Foreach();
        }

        static bool finder(string s)
        {
            return s == "zx";
        }

        private static void Indexer()
        {
            Utils.WriteSubTopic("Indexer");

            Console.WriteLine(l[0]);
            l[0] = "new";
            Console.WriteLine(l[0]);
        }

        private static void Modify()
        {
            Utils.WriteSubTopic("Modify");

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
            Utils.WriteSubTopic("Foreach");

            foreach (System.String s in l)
            {
                Console.WriteLine(s);

            }
        }

        //- pass into l.Sort()
        //      1 - nothing, uses default comparer
        //      2 = Comparison  delegate
        //      3 = an IComparer
        //- l.Reverse
        private static void Sort()
        {
            Utils.WriteSubTopic("Sort");

            //default /////////
            l.Sort();
            Console.WriteLine(string.Join(" ", l));

            l.Reverse();
            Console.WriteLine(string.Join(" ", l));

            //use Comparison delegate
            List<string> l2 = new List<string> { "abc, xyz0", "qrs, def9" };
            l2.Sort((a, b) => a.Substring(5, 3).CompareTo(b.Substring(5, 3)));
            Console.WriteLine(string.Join(" ", l2));

            //use Comparer IComparer (it is class)
            l2.Sort(new MyComparer());
            Console.WriteLine(string.Join(" ", l2));
        }

        private static void Count()
        {
            Utils.WriteSubTopic("Count");
            int n = l.Count();
            Console.WriteLine(n);
        }
    }

    class MyComparer : Comparer<string>
    {
        public override int Compare(string x, string y)
        {
            return (x.Substring(8, 1).CompareTo(y.Substring(8, 1)));
        }
    }
}
