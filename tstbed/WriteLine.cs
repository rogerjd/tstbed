using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    //System.Console.WriteLine
    static public class WriteLine
    {
        static public void Test()
        {
            Console.WriteLine("first and last numbers are: {0} and {7}", 1, 2, 3, 4, 5, 6, 7, 8);
            var n = 55;
            Console.WriteLine($"the value of n is: {n}");
        }
    }
}
