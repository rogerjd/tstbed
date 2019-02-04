using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    /*
     * ref: TimeSpan, a particular time of day (still span, midnight to time)
     *      format: control panel settings, also fmt str
     */

    static class DateTimeTimeSpan
    {
        public static void Test()
        {
            Utils.WriteTopic("DateTime");

            Parse();
            ToStrFmt();
            Now();
            DaysBetween();
            DaysAdd();
            Compare();
            Month();
        }

        // month day year
        private static void Month()
        {
            Utils.WriteSubTopic("Month");

            // can use format string for a particular date  Format("MMM", date)
            DateTime dt = new DateTime(2016, 09, 29);
            Utils.WriteDetailLine(string.Format("{0:MMM}", dt));
            Utils.WriteDetailLine(dt.ToString("MMMM"));
            Utils.WriteDetailLine(dt.ToLongDateString());

            DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
            Utils.WriteDetailLine(dtfi.GetMonthName(3));
            Utils.WriteDetailLine(dtfi.GetAbbreviatedMonthName(4));

            List<string> months = Enumerable.Range(1, 12).Select(tst).ToList();
            Utils.WriteDetailLine(string.Join(" ", months));

            months = Enumerable.Range(1, 12).Select(dtfi.GetAbbreviatedMonthName).ToList();
            Utils.WriteDetailLine(string.Join(" ", months));
        }

        static string tst(int n)
        {
            return n.ToString() + "abc";
        }

        private static void DaysAdd()
        {
            //ng            dt2 += 3;
            //ng dt2 = dt2 + dt1;

            DateTime dt1 = new DateTime(2016, 9, 14);
            dt1 = dt1.AddDays(3);

            TimeSpan ts = new TimeSpan(5, 0, 0, 0);
            DateTime dt2 = dt1 + ts;
        }

        private static void Compare()
        {
            Utils.WriteSubTopic("Compare");

            DateTime dt1 = new DateTime(2016, 9, 14);
            DateTime dt2 = new DateTime(2016, 9, 21);

            Utils.WriteDetailLine(string.Format("{0} > {1} {2}", dt2, dt1, (dt2 > dt1)));
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
            Utils.WriteSubTopic("Days Between");

            DateTime dt1, dt2;
            dt1 = DateTime.Today;
            dt2 = DateTime.Today.AddDays(7);
            TimeSpan ts =  dt2 - dt1;  //ref: or, dt2.Subtract(dt1)
            Console.WriteLine("    " + ts.TotalDays); //fractional days, with time part
            Utils.WriteDetailLine(string.Format("whole days {0}", ts.Days));
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
            //System.DateTime dtOut; /C# 7 allows it to be declared with arg
            bool b = System.DateTime.TryParse(dtIn, out DateTime dtOut);
            Console.WriteLine("  " + b);
            Console.WriteLine("  " + dtOut);
            Console.WriteLine("  " + dtOut.Date); //dt + 12:00:00 *this is date part, cleared time*
            Console.WriteLine("  " + dtOut.ToShortDateString()); 
        }
    }
}
