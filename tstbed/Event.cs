using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    namespace MyCollections
    {
        //ref: can descend from EventArgs, to make specific cases (Mouse, Keyboard, etc)
        public delegate void ChangeDel(Object sender, EventArgs args);

        class Changer
        {
            public event ChangeDel OnChange;

            public void Change()
            {
                //ref: null check  null conditional
                OnChange?.Invoke(this, null); //todo: args ?
            }
        }
    }

    namespace TestEvents
    {
        using MyCollections;

        public static class Event
        {
            //ref: subscriber, can only add/remv handlers for itself. can't do anything that would 
            //     effect other subscribers, so this is illegal 
            //                c.OnChange = null;
            public static void Test()
            {
                Console.WriteLine("Event ****");
                Changer c = new Changer();
                c.OnChange += DoChange;
                c.Change();

                Console.WriteLine("  remv handler");
                c.OnChange -= DoChange;
                c.Change();

                Console.WriteLine("  multicast");
                c.OnChange += DoChange;
                c.OnChange += DoChange;
                c.Change();
            }

            static void DoChange(Object sender, EventArgs args)
            {
                Console.WriteLine("its changed");
            }
        }
    }
}
