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
