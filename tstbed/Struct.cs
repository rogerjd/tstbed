using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    // it is value type
    //    if passing to a method, only the methods copy is changed (use ref?)
    // can not use in inheritance, sealed
    // some people say it should be immutable, use its methods to return a new type if want
    //   to change value; but, i don't know if i agree
    //  A struct cannot have an initializer
    static class Struct
    {
        struct MyStruct 
        {
            public int n;
            public string s;

            //ctor must assign all struct flds
            public MyStruct(int n, string s)
            {
                this.n = n;
                this.s = s;
            }

            public override string ToString()
            {

                return n.ToString() + " " + s;
            }
        }

        public static void Test()
        {
            Console.WriteLine("Struct ****");

            MyStruct ms = new MyStruct(2, "abc");

            Console.WriteLine(ms);
            paramValue(ms);
            Console.WriteLine(ms);

            Console.WriteLine(ms);
            paramRef(ref ms);
            Console.WriteLine(ms);
        }

        static void paramValue(MyStruct ms)
        {
            Console.WriteLine("paramValue **");
            ms.n = 5;
        }

        static void paramRef(ref MyStruct ms)
        {
            Console.WriteLine("paramRef **");
            ms.n = 5;
        }

    }
}
