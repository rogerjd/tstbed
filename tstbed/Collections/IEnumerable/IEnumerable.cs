using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Collections
{
    class IEnumerableTst : IEnumerable
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerable();
        }

        IEnumerator GetEnumerable()
        {
            return new MyEnum();
        }
    }

    static class EnumerableTest
    {
        public static void Test()
        {
            //linq
            //                   //ten elements, 0..9
            var n = Enumerable.Range(0, 10).Count(i => i % 2 == 0);
            Console.WriteLine(n);
        }
    }

    class MyEnum : IEnumerator
    {
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
