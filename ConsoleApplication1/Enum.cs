using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Enum
    {
        public enum DaysOfWeek { Mon, Tue, Wed, Thu, Fri, Sat, Sun };

        static Enum()
        {
            Console.WriteLine("{0}, {1}", DaysOfWeek.Mon, (int)DaysOfWeek.Mon);
        }
    }
}
