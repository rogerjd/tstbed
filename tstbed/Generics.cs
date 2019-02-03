using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{

    /*
     * the type parameter <T> can be used on types(c/s/i/d) and methods only
     *   others can use, but not introduce. also, a method can use without introduce, too
     *   
     * default(T): returns default val for T, ref type = null, val type 0
     * 
     * constraints:
    */

    delegate int tst(string s);

    class Stack<T>
    {
        int position;
        T[] data = new T[100];
        public void Push(T obj) => data[position++] = obj;
        public T Pop() => data[--position];
    }

    class Generics
    {
        internal static void Test()
        {
            Utils.WriteTopic("Generics");

            GenericStack();
            TypeParameter();
            TestDelegateGeneric();
        }

        private static void GenericStack()
        {
            Utils.WriteSubTopic("Generic Stack");

            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(10);

            Utils.WriteDetailLine(stack.Pop().ToString());
            Utils.WriteDetailLine(stack.Pop().ToString());
        }

        private static void TypeParameter()
        {
            Utils.WriteSubTopic("Type Parameter");

            int totalLength(string s1, string s2) => s1.Length + s2.Length; //local func w/lambda
            //ok  above    Func<string, string, int> totalLength = (s1, s2) => s1.Length + s2.Length;
            int total = totalLength("abc", "defg");
            Utils.WriteDetailLine(string.Format("{0} + {1} = {2}", "abc", "defg", total));
        }

        static void GenericMethod<T>(T s)
        {

        }

        static void GenericMethod2<T>(T s)
        {

        }

        static void TestDelegateGeneric()
        {
            var str = "Hello";
            var l = Mapper(str, GetOrdinalValue);
            var l2 = Mapper(str, GetUpperCase);
        }

        static List<T> Mapper<T>(string str, Func<char, T> func)
        {
            List<T> ts = new List<T>();
            foreach (char c in str)
            {
                ts.Add(func(c));
            }
            return ts;
        }

        static int GetOrdinalValue(char c)
        {
            return (int)c;
        }

        static char GetUpperCase(char c)
        {
            return Char.ToUpper(c);
        }
            
    }
}
