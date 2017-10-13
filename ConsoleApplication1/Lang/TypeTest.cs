using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Lang
{
    static class TypeTest
    {
        static public void Test()
        {
            Utils.WriteTopic("Type test");
            ArrayTst();
            IsUnassignableFrom();
        }

        private static void IsUnassignableFrom()
        {
            int n1 = 23;
            string s = "abc";

            var b = n1.GetType().IsAssignableFrom(s.GetType());

            //typeof(n1.GetType()).IsAssignableFrom(s.GetType());
        }

        private static void ArrayTst()
        {
            Utils.WriteSubTopic("Array");

            string[] a = new string[] { "a", "b", "c" };

            ICollection<string> c = a as ICollection<string>;
            Utils.WriteDetailLine("Array implements ICollection<T>: " + (c != null).ToString());
            Utils.WriteDetailLine("Array implements ICollection<T>: " + (a is ICollection<string>).ToString());
        }
    }
}
