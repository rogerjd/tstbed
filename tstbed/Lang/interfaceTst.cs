using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Lang
{
    class interfaceTst : IEnumerable
    {

        public static void Test()
        {
            Utils.WriteTopic("Interface");
            var c = new intfTst();
            tst(c);
            var c2 = new intfTstA();
            tst(c2);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); //not recursion,  because explicitly implemented
        }


        IEnumerator GetEnumerator()
        {
            return null;
        }

        static void tst(intf a)
        {
            a.Hello();
        }
    }

    interface intf
    {
        void Hello();
    }

    class intfTst : intf
    {
        public void Hello()
        {
            Console.WriteLine("Joe");
        }

        void tst(intf a) { }
    }

    class intfTstA : intf
    {
        public void Hello()
        {
            Console.WriteLine("Jane");
        }

        void tst(intf a) { }
    }

}
