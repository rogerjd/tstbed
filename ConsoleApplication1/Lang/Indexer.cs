using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Lang
{
    static class IndexerTst
    {

        class SampleCollection<T>
        {
            T[] arr = new T[12];

            public T this[int i]
            {
                get => arr[i];
                set => arr[i] = value;
            }
        }

        static public void Test()
        {
            Utils.WriteTopic("Indexer");
            var coll = new SampleCollection<string>();
            coll[0] = "Hello";
            Utils.WriteDetailLine(coll[0]);
        }
    }

}
