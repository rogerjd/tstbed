using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    namespace MyCollections
    {
        public delegate void ChangeDel();
        class Changer
        {
            public event ChangeDel OnChange;

            public void Change()
            {
                if (OnChange != null)
                {
                    OnChange(); //todo: args ?
                }
            }
        }
    }

    namespace TestEvents
    {
        using MyCollections;

        public static class Event
        {
            public static void Test()
            {
                Console.WriteLine("Event ****");
                Changer c = new Changer();
                c.OnChange += DoChange;
                c.Change();
            }

            static void DoChange()
            {
                Console.WriteLine("its changed");
            }
        }
    }
}
