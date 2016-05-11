using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Linq
    {
        public static void Test()
        {
            Console.WriteLine("Linq");
            zipTst();
            DB();
        }

        static private void zipTst()
        {
            Console.WriteLine("zip");
            List<string> l1 = new List<string> { "a", "b", "c" };
            List<string> l2 = new List<string> { "1", "2", "3" };

            var dic = l1.Zip(l2, (a, b) => new { b, a }).ToDictionary(x => x.b, x => x.a);
            foreach (var i in dic)
            {
                Console.WriteLine(i);
            }



//converts int to string automatically
            l1 = new List<string> { "a", "b", "c" };
            List<int> l3 = new List<int> { 1, 2, 3 };

            var l4 = l1.Zip(l2, (a, b) => a + " " + b );
            foreach (var s in l4)
            {
                Console.WriteLine(s);
            }
        }

        static void DB()
        {

        }
    }
}
