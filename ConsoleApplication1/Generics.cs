using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

/*
 * the type parameter <T> can be used on types(c/s/i/d) and methods only
 *   others can use, but not introduce. also, a method can use without introduce, too
 *   
 * default(T): returns default val for T, ref type = null, val type 0
 * 
 * constraints:
*/

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
            Console.WriteLine("Generics ****");
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(10);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }

        static void GenericMethoc<T>(T s)
        {

        }
    }
}
