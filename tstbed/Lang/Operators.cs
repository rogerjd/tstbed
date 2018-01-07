using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Lang
{
    static class Operators
    {
        public static void Test()
        {
            Utils.WriteTopic("Operators");

            NullCoalesce(); //??
            EqualEqual(); //.Equality compares values   == compares refs excpet for string it is value
        }

        //For predefined value types, the equality operator (==) 
        //returns true if the values of its operands are equal, false otherwise.
        //For reference types other than string, == returns true 
        //if its two operands refer to the same object. 
        //For the string type, == compares the values of the strings.
        private static void EqualEqual()
        {
            void ValueType()
            {
                int n, m;
                n = 3;
                m = 3;
                if (n == m)
                {
                    Utils.WriteDetailLine("equal");
                }
            }

            void ReferenceType()
            {
                //str const/literal are in the intern/string pool (by default): eliminates dups
                void str()
                {
                    String a = "hello";
                    String b = String.Copy(a);
                    String c = "hello";

                    if (a == c)
                    {
                        Utils.WriteDetailLine("values are the same");
                    }

                    if ((object)a == (object)c)
                    {
                        Utils.WriteDetailLine("the refs are the same, becuase of str pool, there is only 1 str w/2 refs");
                    }

                    if ((object)a == (object)b)
                    {
                        //Utils.WriteDetailLine("the references are equal, because of string/intern pool, there in only one str, w/2 refs to it");
                    }
                    else
                    {
                        Utils.WriteDetailLine("values are the same, but there are 2 different refs");
                    }

                    if (a == b)
                    {
                        Utils.WriteDetailLine("a == b because values are equal");

                    }

/*
                    if (a == b)
                    {
                        Utils.WriteDetailLine("should not be equal, refs/addresses are different");
                    }
                    else
                    {
                        Utils.WriteDetailLine("unequal, becuase of different memory locations(refs)");
                    }
*/
                }

                List<int> l1 = new List<int> { 1, 2, 3 };
                List<int> l2 = new List<int> { 1, 2, 3 };
                if (l1 == l2)
                {
                    Utils.WriteDetailLine("should not be equal");
                }

                str();
            }

            Utils.WriteSubTopic("==");
            ValueType();
            ReferenceType();
        }

        //??
        private static void NullCoalesce()
        {
            Utils.WriteSubTopic("Null Coalesce ??");
            int? n = null;
            int i = n ?? 3;
            Utils.WriteDetailLine(i.ToString());
            n = 2;
            i = n ?? -1;
            Utils.WriteDetailLine(i.ToString());
        }
    }
}
