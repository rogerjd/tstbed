using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            GetFields();
        }

        class Emp
        {
            public string Name;
            public int ID;
        }

        private static void GetFields()
        {
            Utils.WriteSubTopic("Get Fields");
            var e = new Emp() { Name = "Jj", ID = 2133 };
            foreach (FieldInfo fi in e.GetType().GetFields())
            {
                Utils.WriteDetailLine(fi.Name + " " + fi.GetValue(e));
            }
        }

        private static void IsUnassignableFrom()
        {
            int n1 = 23;
            string s = "abc";

            var b = n1.GetType().IsAssignableFrom(s.GetType());

            var t1 = n1.GetTypeCode();
            Utils.WriteDetailLine("int's type code is: " + t1);

            var t = typeof(int);

            b = n1 is int;

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
