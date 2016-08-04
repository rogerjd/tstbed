using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class DateTimeTst
    {
        public static void Test()
        {
            Console.WriteLine("DateTime ****");
            Parse();
            Now();
        }

        private static void Now()
        {
            Console.WriteLine("Now **");
            Console.WriteLine("  " + DateTime.Now);
        }

        private static void Parse()
        {
            Console.WriteLine("Parse **");
            string dtIn = "09/01/2015 01:13:34";
            System.DateTime dtOut;
            bool b = System.DateTime.TryParse(dtIn, out dtOut);
            Console.WriteLine("  " + b);
            Console.WriteLine("  " + dtOut);
            Console.WriteLine("  " + dtOut.Date); //dt + 12:00:00 *this is date part, cleared time*
            Console.WriteLine("  " + dtOut.ToShortDateString()); 
        }
    }
}
