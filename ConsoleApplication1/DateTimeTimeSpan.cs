using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class DateTimeTimeSpan
    {
        public static void Test()
        {
            Console.WriteLine("DateTime ****");
            Parse();
            ToStrFmt();
            Now();
            DaysBetween();
        }

        private static void ToStrFmt()
        {
            Console.WriteLine("To String **");

            DateTime dt = DateTime.Now;

            Console.WriteLine("  " + dt.ToString(""));
            Console.WriteLine("  " + dt.ToString("MM/dd/yy"));
            Console.WriteLine("  " + dt.ToString("MMM dd yyyy"));
            Console.WriteLine("  " + dt.ToString("MMMM"));
            Console.WriteLine("  " + dt.ToString("ddd"));
            Console.WriteLine("  " + dt.ToString("dddd"));
            Console.WriteLine("  " + dt.ToString("hh:mm tt"));
        }

        private static void DaysBetween()
        {
            Console.WriteLine("Days Between **");

            DateTime dt1, dt2;
            dt1 = DateTime.Today;
            dt2 = DateTime.Today.AddDays(7);
            TimeSpan ts =  dt2 - dt1;  //ref: or, dt2.Subtract(dt1)
            Console.WriteLine("    " + ts.TotalDays);
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
