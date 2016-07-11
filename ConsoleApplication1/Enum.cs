using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    /*
     *  declare: namespace, class or struct
    */
    class MyEnum
    {
        //holds integer types
        //starts with 0, unless othewise specified
        //to/from string; parse, ToString
        //[Flags]
        //Enum.GetNames(e.GetType()), GetValues()
        public enum MyDaysOfWeek { Mon, Tue, Wed, Thu, Fri, Sat, Sun };

        enum noZeroEnum { a = 1, b = 3 };

        static noZeroEnum tstEnum;

        static MyEnum()
        {
            Console.WriteLine("Enum ****");

            Console.WriteLine("{0}, {1}", MyDaysOfWeek.Mon, (int)MyDaysOfWeek.Mon);

            MyDaysOfWeek md = MyDaysOfWeek.Mon;
            md.Count();

            CountOfElements(md);
            LoopThruElements();
            ZeroElement();
            CastToEnum();
        }

        private static void CastToEnum()
        {
            Console.WriteLine("Cast to enum");

            //out of range, no error
            noZeroEnum n = (noZeroEnum)5; //5
            Console.WriteLine(n);

            //in range
            n = (noZeroEnum)1;
            Console.WriteLine(n);  //a
        }

        private static void LoopThruElements()
        {
            foreach (MyDaysOfWeek md in Enum.GetValues(typeof(MyDaysOfWeek)))
            {
                Console.WriteLine(md);
            }
        }

        //ref: returns Array, use Length prop
        private static void CountOfElements(Enum e)
        {
            Enum.GetValues(typeof(ConsoleApplication1.MyEnum.MyDaysOfWeek));
            var a = Enum.GetValues(e.GetType());
            a = Enum.GetNames(e.GetType());
        }


        //ref: should always have a 0/default elemnt, else 
        //just so that if a class member of that enumeration is not initialized properly, the uninitialized value can easily be spotted
        private static void ZeroElement()
        {
            Console.WriteLine("ZeroElement");

            Console.WriteLine(tstEnum);
            
            //ref: now its init'd
            tstEnum = noZeroEnum.a;
            Console.WriteLine(tstEnum);

            /*
                        Array a = Enum.GetValues(typeof(x));
                        int n = a.Length;
                        Console.WriteLine(n);
            */
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
