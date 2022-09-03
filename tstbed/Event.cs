using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    namespace MyCollections
    {
        public class SampleEventArgs
        {
            public SampleEventArgs(string s)
            {
                Text = s;
            }
            public string Text { get; }
        }

        //ref: can descend from EventArgs, to make specific cases (Mouse, Keyboard, etc)
        public delegate void ChangeDel(Object sender, EventArgs args);

        class Changer
        {
            public event EventHandler Change;
            //https://stackoverflow.com/questions/2282476/actiont-vs-delegate-event
            public event EventHandler<EventArgs> Leave;

            protected void OnChange()
            {
                //ref: null check  null conditional. else
                //    protected virtual void OnLeave(EmployeeEventArgs e)
                //    {
                //      var handler = Leave;
                //      if (handler != null) handler(this, e);
                //    }
                Change?.Invoke(this, new EventArgs()); //todo: args ?
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
                c.Change += DoChange;
                //c.OnChange();

                Console.WriteLine("  remv handler");
                c.Change -= DoChange;
                //c.OnChange();

                Console.WriteLine("  multicast");
                c.Change += DoChange;
                c.Change += DoChange;
                //c.OnChange();
            }

            static void DoChange(Object sender, EventArgs args)
            {
                Console.WriteLine("its changed");
            }
        }
    }
}
