using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    /*
     *  - declare: namespace, class or struct
     *  - should define a zero val. else, will be init'd to zero (class fld), and thus
     *    hold invalid val
     *  - cast of an out of range int, is not a prob/err, just returns the int
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
            EnumDefinedValid();
            PassAsParam(MyDaysOfWeek.Mon);
            GetLongNamesArrayToStr();
        }

        private static void GetLongNamesArrayToStr()
        {
            //todo: array or attribute?

            248
down vote
I do this with extension methods:

public enum ErrorLevel
        {
            None,
            Low,
            High,
            SoylentGreen
        }

        public static class ErrorLevelExtensions
        {
            public static string ToFriendlyString(this ErrorLevel me)
            {
                switch (me)
                {
                    case ErrorLevel.None:
                        return "Everything is OK";
                    case ErrorLevel.Low:
                        return "SNAFU, if you know what I mean.";
                    case ErrorLevel.High:
                        return "Reaching TARFU levels";
                    case ErrorLevel.SoylentGreen:
                        return "ITS PEOPLE!!!!";
                    default:
                        return "Get your damn dirty hands off me you FILTHY APE!";
                }
            }
        }

    }

        private static void PassAsParam(MyDaysOfWeek md)
        {
            switch (md)
            {
                case MyDaysOfWeek.Mon:
                    Utils.WriteDetailLine(md.ToString());
                    break;
                case MyDaysOfWeek.Tue:
                    break;
                case MyDaysOfWeek.Wed:
                    break;
                case MyDaysOfWeek.Thu:
                    break;
                case MyDaysOfWeek.Fri:
                    break;
                case MyDaysOfWeek.Sat:
                    break;
                case MyDaysOfWeek.Sun:
                    break;
                default:
                    break;
            }
        }

        //test if value is within set of defined enum elements
        //  see also, Enum.Defined, however is does not work for flags
        private static void EnumDefinedValid()
        {
            Console.WriteLine("EnumDefinedValid **");

            //out of range, no error
            noZeroEnum n = (noZeroEnum)5; //5
            int d;
            bool def = !int.TryParse(n.ToString(), out d);
            Console.WriteLine("  defined: {0}", def);

            n = (noZeroEnum)1; //a = 1
            def = !int.TryParse(n.ToString(), out d);
            Console.WriteLine("  defined: {0}", def);
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
            Console.WriteLine("Count of elements **");
            var a = Enum.GetValues(typeof(ConsoleApplication1.MyEnum.MyDaysOfWeek));
            Console.WriteLine(a.Length);
            a = Enum.GetValues(e.GetType());  // Mon; not string
            Console.WriteLine(a.Length);
            a = Enum.GetNames(e.GetType()); //this string, i think. eg: "Mon"
            Console.WriteLine(a.Length);
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
