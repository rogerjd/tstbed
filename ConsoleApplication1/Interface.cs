using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Interface
    {

        public interface Tster
        {
            void Tst1();
        }

        static public void Test()
        {
            MyClass mc = new MyClass();
            mc.Tst1();

            MyClass2 mc2 = new MyClass2();
            mc2.Tst1();

            //only interface methods are available through the interface
            //Tster t = mc;
            //t.AnotherMethod();
        }
    }

    class MyClass : Interface.Tster
    {
        public void Tst1()
        {
            System.Console.WriteLine("Interface: MyClass.Tst1");
        }

        public void AnotherMethod()
        {
            Console.WriteLine("AnotherMethod()");
        }
    }

    class MyClass2 : Interface.Tster
    {
        public void Tst1()
        {
            System.Console.WriteLine("Interface: MyClass2.Tst1");
        }
    }
}
