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

        static void tst(Iintf a)
        {
            a.Hello();
        }
    }

    interface Iintf
    {
        void Hello();
    }

    class intfTst : Iintf
    {
        public void Hello()
        {
            Console.WriteLine("Joe");
        }

        void tst(Iintf a) { }
    }

    class intfTstA : Iintf
    {
        public void Hello()
        {
            Console.WriteLine("Jane");
        }

        void tst(Iintf a) { }
    }

}
