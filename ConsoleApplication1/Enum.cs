using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class MyEnum
    {
        //holds integer types
        //starts with 0, unless othewise specified
        //to/from string; parse, ToString
        //[Flags]
        //Enum.GetNames(e.GetType()), GetValues()
        public enum MyDaysOfWeek { Mon, Tue, Wed, Thu, Fri, Sat, Sun };

        static MyEnum()
        {
            Console.WriteLine("{0}, {1}", MyDaysOfWeek.Mon, (int)MyDaysOfWeek.Mon);

            MyDaysOfWeek md = MyDaysOfWeek.Mon;
            md.Count();

            CountOfElements();
        }

        private static void CountOfElements()
        {
            Enum.GetValues(typeof(ConsoleApplication1.MyEnum.MyDaysOfWeek));
        }
    }

    static class EnumUtils
    {
        //ref: extension method
        public static int Count(this ConsoleApplication1.MyEnum.MyDaysOfWeek e)
        {
            return 0;
        }
    }

}
