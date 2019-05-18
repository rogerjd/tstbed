using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tstbed.TestEvents;
using System.Diagnostics;
using tstbed.Net;

namespace tstbed
{
    struct myStruct
    {

    }

    enum myEnum
    {

    }

    interface myIntf
    {

    }

    delegate void MyDelegate();

    class MyTstClass
    {

    }

    //MyTstClass mc = new MyTstClass(); //CS0116 namespace cannot directly contain members such as fields or methods

    class Program
    {
        static void Main(string[] args)
        {

            //cmd ln 
            // can set in iDE. Prj.Properties\Debug\CmdLnParams
            if (args.Length == 2)
            {
                Console.WriteLine("{0} {1}", args[0], args[1]);
            }
            Utils.WriteDetailLine(args.Length.ToString());

            //name of pgm. there are other ways
            Console.WriteLine(Process.GetCurrentProcess().ProcessName);

            /*           
                        new Delegates();

                        Collections.Dict.Test();

                        Linq.Test();

                        IO.Test();

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
            */

            #region Desk
            switch (Utils.GetCmdArg(args, 0))
            {
                case "lang":
                    Lang.Main.Test(args);
                    break;
                case "DB":
                    DB.Main.Test(args); //lengthy
                    break;
                case "collections":
                    Collections.Dict.Test();
                    Collections.Lookup.Test();
                    Collections.List.Test();
                    break;
                case "WriteLine":
                    WriteLine.Test();
                    break;
                case "object":
                    ObjectTst.Test();
                    break;
                case "string":
                    StringTst.Test();
                    break;
                default:
                    Utils.WriteDetailLine("Arg 0 not found");
                    break;
            }
            #endregion

            /*
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

            */

            /*
            howto.sort.SortTst.Test();

            Net.Http.WebRequestTst.Test();

            Lang.IndexerTst.Test();
            Lang.Operators.Test();
            Lang.interfaceTst.Test();

                        Directoy_File_Path.Dir.Test();

            Directoy_File_Path.File_tst.Test();
            Directoy_File_Path.Dir.Test();
            Directoy_File_Path.PathTst.Test();

            Collections.SequenceEqual.Test();

            DNSTst.Test();
            */



            Console.WriteLine("press any key to exit(async may not have ended)");
            Console.ReadKey();
        }
    }
}
