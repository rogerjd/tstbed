using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Collections
{
    //it is not a dictionary (key/value), only one value/item
    static class HashSetTst
    {
        public static void Test()
        {
            Console.WriteLine("\nHASH SET ****");

            //ok            HashSet<int> hs = new HashSet<int> {1, 2, 4 };
            var hs = new HashSet<int>(new int[] { 1, 2, 3, 4, 5, 6 });

            bool b = hs.Contains(14);
            Console.WriteLine("  contains 14: {0} **", b);

            b = hs.Contains(4);
            Console.WriteLine("  contains 4: {0} **", b);

            Console.WriteLine("  count: {0} **", hs.Count());

            hs.Add(7);
            Console.WriteLine("  after add, count: {0} **", hs.Count());
        }
    }
}
