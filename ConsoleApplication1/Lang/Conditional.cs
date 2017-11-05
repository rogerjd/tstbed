using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Lang
{
    static class Conditional
    {
        static public void Test()
        {
            Utils.WriteTopic("Conditional Operators");
            If();
            Switch();
            NullConditionalOperator();
            NullCoalesce();
        }

        //ref: test left hand operator, if not null return it, else return right hand
        private static void NullCoalesce()
        {
            Utils.WriteSubTopic("null coalesce");
            int? a, b;
            a = b = null;
            int? n = a ?? b;
            Utils.WriteDetailLine(n.ToString());

            b = 3;
            n = a ?? b;
            Utils.WriteDetailLine(n.ToString());

            a = 4;
            b = null;
            n = a ?? b;
            Utils.WriteDetailLine(n.ToString());
        }

        //ref: ?. or ?[  (use to access a member or indexer)
        //      usage: sb?.ToString()   //if sb == null, return null, else call its ToString() method
        //     return null or the result of ....
        private static void NullConditionalOperator()
        {
            Utils.WriteSubTopic("null conditional");

            StringBuilder sb = null;
            string s = sb?.ToString();
            Utils.WriteDetailLine(string.Format("sb is null? {0}", sb == null));

            sb = new StringBuilder("abc");
            s = sb?.ToString();
            Utils.WriteDetailLine(string.Format("sb is null? {0} sb.ToString(): {1}", sb == null, sb.ToString()));
        }

        static void If()
        {
            Console.WriteLine("  if **");
            if (3 < 2)
                Console.WriteLine("    3 < 2");
            else
            {
                Console.WriteLine("    3 is equal to or greater than 2");
            }
        }

        static void Switch()
        {
            Console.WriteLine("  switch **");

            //ref: no range in case. can use fall through, or if (x > && x <)  for range of values
            int n = 3;
            switch (n)
            {
                case 1:
                    Console.WriteLine("    n == 1");
                    break;
                case 2:
                    Console.WriteLine("    n == 2");
                    break;
                default:
                    Console.WriteLine("    n not 1 or 2");
                    break;
            }
        }
    }
}
