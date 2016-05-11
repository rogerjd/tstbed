using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Conditional
    {
        static public void Test()
        {
            If();
            Switch();
        }

        static void If()
        {
            if (3 < 2)
                Console.WriteLine("3 < 2");
            else
            {
                Console.WriteLine("3 is equal to or greater than 2");
            }
        }

        static void Switch()
        {
            //ref: no range in case. can use fall through, or if (x > && x <)  for range of values
            int n = 3;
            switch (n)
            {
                case 1:
                    Console.WriteLine("n == 1");
                    break;
                case 2:
                    Console.WriteLine("n == 2");
                    break;
                default:
                    Console.WriteLine("n not 1 or 2");
                    break;
            }
        }
    }
 
}
