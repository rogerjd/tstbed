using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tstbed.TestEvents;
using System.Diagnostics;

namespace tstbed
{
    class Program
    {
        static void Main(string[] args)
        {
            //cmd ln 
            // can set in iDE. Prj.Properties.CmdLnParams
            Console.WriteLine("{0} {1}", args[0], args[1]);
            Utils.WriteDetailLine(args.Length.ToString());

            //name of pgm. there are other ways
            Console.WriteLine(Process.GetCurrentProcess().ProcessName);

            new Delegates();

            Collections.Dict.Test();

            Linq.Test();

            IO.Test();

            new Dir();

            new MyEnum();

            //            new String();

            StringTst.Test();

            Loop.Test();

            //            DB.Test(); lengthy
            //            DB.DataReaderTst.Test(); lengthy

            DB.DataTableTst.Test();
            Lang.Conditional.Test();

            Method.Test();

            Interface.Test();

            ExtensionMenthods.Test();

            DependencyInjection.Test();

            Collections.HashSetTst.Test();

            Collections.List.Test();

            ArrayTst.Test();

            Struct.Test();

            Event.Test();

            DateTimeTimeSpan.Test();

            Generics.Test();

            Lang.Lang.Test();

            StringBuilderTst.Test();

            Numbers.Test();

            TupleTst.Test();

            Operators.Test();

            TimerTst.Test();

            GCTst.Test();

            TraceDebug.Test();

            AsyncTst.Test();

            Closure.Test();

            Lang.TypeTest.Test();

            howto.sort.SortTst.Test();

            Net.Http.WebRequestTst.Test();

            Lang.IndexerTst.Test();

            Console.WriteLine("press any key to exit(async may not have ended)");
            Console.ReadKey();
        }
    }
}
