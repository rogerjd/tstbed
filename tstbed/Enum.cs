﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{

    /*
     *  - declare: namespace, class or struct
     *  - should define a zero val. else, will be init'd to zero (class fld), and thus
     *    hold invalid val
     *  - cast of an out of range int, is not a prob/err, just returns the int
    */
    static class MyEnum
    {
        //holds integer types
        //starts with 0, unless othewise specified
        //to/from string; parse, ToString
        //[Flags]
        //Enum.GetNames(e.GetType()), GetValues()
        public enum MyDaysOfWeek { Mon, Tue, Wed, Thu, Fri, Sat, Sun };
        enum noZeroEnum { a = 1, b = 3 };

        static noZeroEnum tstEnum;
        public static void Test()
        {
            Console.WriteLine("Enum ****");

            Console.WriteLine("{0}, {1}", MyDaysOfWeek.Mon, (int)MyDaysOfWeek.Mon);

            MyDaysOfWeek md = MyDaysOfWeek.Mon;
            md.Count();
            //MyDaysOfWeek.Count();

            LoopTst();

            CountOfElements(md);
            CountNumElements(typeof(MyDaysOfWeek));
            LoopThruElements();
            ZeroElement();
            Cast();
            PassAsParam(MyDaysOfWeek.Mon);
            GetLongNamesArrayToStr();
            ElemToString();
            ParseEnum();
        }

        private static void ParseEnum()
        {
            var e = Enum.Parse(typeof(MyDaysOfWeek), "Mon");
        }

        private static void ElemToString()
        {
            Console.WriteLine(MyDaysOfWeek.Mon.ToString());
        }

        private static int CountNumElements(Type md)
        {
            return Enum.GetNames(md).Length;
        }

        private static void LoopTst()
        {
            foreach (MyDaysOfWeek md in Enum.GetValues(typeof(MyDaysOfWeek)))
            {
                Console.WriteLine(md);
            }
        }

        private static void GetLongNamesArrayToStr()
        {
            //todo: array or attribute?

            /*
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
            */
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
        private static void Cast()
        {
            Console.WriteLine("Cast EnumDefinedValid **");

            //out of range, no error
            //undefined
            noZeroEnum n = (noZeroEnum)5; //5
            //int d; variable declaration can be inlined
            bool def = !int.TryParse(n.ToString(), out int d);
            Console.WriteLine("  defined: {0}", def);

            n = (noZeroEnum)1; //a = 1
            def = !int.TryParse(n.ToString(), out d);
            Console.WriteLine("  defined: {0}", def);

            n = (noZeroEnum)3; //b = 3  it is not index, but value
            def = !int.TryParse(n.ToString(), out d);
            Console.WriteLine("  defined: {0}", def);

            int p = (int)n;
            Console.WriteLine(p); //3

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
            Console.WriteLine("Count of elements **");
            var myEnumMemberCount = Enum.GetNames(typeof(MyEnum.MyDaysOfWeek)).Length;

            var a = Enum.GetValues(typeof(tstbed.MyEnum.MyDaysOfWeek));
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
            Console.WriteLine(tstEnum);  //same as ToString
            tstEnum = noZeroEnum.b;
            Console.WriteLine(tstEnum.ToString());
            Console.WriteLine((int)tstEnum);

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
        public static int Count(this tstbed.MyEnum.MyDaysOfWeek e)
        {
            return Enum.GetNames(e.GetType()).Length;
        }
    }

}
