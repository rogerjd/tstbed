using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    struct x { };

    static class lang
    {
        static x z;

        internal static void Test()
        {
            Utils.WriteTopic("Language");

            x a;
            DeclareInitVariables();
        }

        private static void DeclareInitVariables()
        {
            Utils.WriteSubTopic("Declare and Init Variables");
            //ok            int a, b, c;  //declare only

//ok            int a, b, c = 0;  //only c is assigned, a and b are declared only

            //ok            int a =0, b = 1, c = 2;   //declare and assign

            int a, b, c;  //ok
            a = b = c = 0;  //ok
            Utils.WriteDetailLine(string.Format("a: {0} b: {1} c:{2}" , a.ToString(), b.ToString(), c.ToString()));
        }
    }
}
