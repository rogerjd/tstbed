using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    static class Interface
    {

        public interface ITster
        {
            void Tst1();
        }

        static public void Test()
        {
            Utils.WriteTopic("Interface");

            MyClass mc = new MyClass();
            mc.Tst1();

            MyClass2 mc2 = new MyClass2();
            mc2.Tst1();

            MyClass3 mc3 = new MyClass3();
            mc3.Tst1();

            //only interface methods are available through the interface
            //Tster t = mc;
            //t.AnotherMethod();

            PassToInterfaceParameter();

            MyClass4 mc4 = new MyClass4();
            //            mc4.Tst1();  //cs1061, does not implement interface

            MyStruct ms;
            ms.Tst1();

            PassAsParam(ms);
            PassAsParam(mc3);

            List<ITster> l = new List<ITster> { mc, mc2, mc3, ms };
            PassAsList(l);
        }

        private static void PassAsList(IEnumerable<ITster> l)
        {
            Utils.WriteSubTopic("pass a list");
            foreach (ITster item in l)
            {
                item.Tst1();
            }
        }

        private static void PassAsParam(ITster i)
        {
            Utils.WriteSubTopic("pass as param");
            i.Tst1();
        }

        private static void PassToInterfaceParameter()
        {
            Utils.WriteSubTopic("Parameter");
            List<int> l = new List<int> { 1, 2, 3, 4, 5 };
            DoSomething(l);
        }

        private static void DoSomething(IList<int> l)
        {
            Utils.WriteDetailLine(l.Count.ToString());
        }
    }

    class MyClass : Interface.ITster
    {
        public void Tst1()
        {
            Utils.WriteDetailLine("Interface: MyClass.Tst1 or 3");
        }

        public void AnotherMethod()
        {
            Console.WriteLine("AnotherMethod()");
        }
    }

    class MyClass2 : Interface.ITster
    {
        public void Tst1()
        {
            Utils.WriteDetailLine("Interface: MyClass2.Tst1");
        }
    }

    //must this implements the interface it gets from the parent class? it inherits the 
    //  implementation, but can override if it wishes
    class MyClass3 : MyClass
    {

    }

    class MyClass4
    {

    }

    struct MyStruct : Interface.ITster
    {
        public void Tst1()
        {
            Utils.WriteDetailLine("struct implementing an interface");
        }
    }
}
