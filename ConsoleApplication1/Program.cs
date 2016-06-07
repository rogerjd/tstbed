using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0} {1}", args[0], args[1]);
            new Delegates();

            new Dict();

            Linq.Test();

            new File();

            new Dir();

            new Enum();

            new String();

            Loop.Test();

            DB.Test();

            Conditional.Test();

            Method.Test();

            Interface.Test();

            ExtensionMenthods.Test();

            DependencyInjection.Test();

            Console.ReadKey();
        }
    }
}
