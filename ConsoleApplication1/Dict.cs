using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Dict
    {
        static Dictionary<string, string> d = new Dictionary<string, string> { ["abc"] = "123" }; //ref: or {{"k", "v"}}

        public static void Test()
        {
            Console.WriteLine("Dictionary ****");
            Loop();
            count();
        }

        private static void count()
        {
            Console.WriteLine("count **");
            Console.WriteLine(d.Count);
        }

        static void Loop()
        {
            Console.WriteLine("Loop **");
            foreach (var item in d)
            {
                Console.WriteLine(item);
            }
        }
    }
}
