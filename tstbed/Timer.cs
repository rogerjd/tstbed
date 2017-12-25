using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApplication1
{
/* must Dispose the Timer, else it and its object are kept alive(.Net holds ref so can fire elapsed event)
 *   Finalize not best way (it can call dispose)
 */
    static class TimerTst
    {
        public static void Test()
        {
            TmrTst();
        }

        private static void TmrTst()
        {
            using (new TmrTstr())
            {
                Console.ReadLine();
            }
        }
    }

    class TmrTstr: IDisposable
    {
        Timer tmr;

        public TmrTstr()
        {
            tmr = new Timer(1000);
            tmr.Elapsed += Tmr_Elapsed;
            tmr.Start();
        }

        private void Tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("time elapsed");
        }

        public void Dispose()
        {
            tmr.Dispose();
        }
    }
}
