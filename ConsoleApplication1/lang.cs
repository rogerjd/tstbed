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

            NewConstructInit();

            Equality();

            VarDeclareInit();
        }

        private static void VarDeclareInit()
        {
            Utils.WriteTopic("Var Declare Init");
            int n = 3, b = 4, c = n + 1;
            Utils.WriteDetailLine(string.Format("{0} {1} {2}", n, b, c));
        }

        private static void Equality()
        {
            //IEquatable<T> saves the overhead of boxing a value type into an object
            //  object.Equals(object x)
            // Equals  and GetHashCode   (and other Comparison methods should agree)
        }

        private static void NewConstructInit()
        {
            //must have one or the other or both, () must come first
            List<int> l = new List<int>() { };

//            System.Collections.ArrayList al = new System.Collections.ArrayList;
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
