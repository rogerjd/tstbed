using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Lang

{
    struct X { };

    static class Lang
    {
        static X z;

        internal static void Test()
        {
            Utils.WriteTopic("Language");

            X a;
            DeclareInitVariables();

            NewConstructInit();

            Equality();

            ScopeAndDeclarationSpace();

            NamedAndOptionalDefaultArgs();

            AnonymousObject();

//            Params() see, Method params
        }

        private static void AnonymousObject()
        {
            var obj = new { fn = "joe", ln = "smith" };
            Console.WriteLine(obj);

            string fn, ln;
            fn = "pete";
            ln = null;
            var obj2 = new { fn, ln }; //name and value at once
            Console.WriteLine(obj2);
        }

        private static void Params()
        {
            throw new NotImplementedException();
        }

        private static void NamedAndOptionalDefaultArgs()
        {
            //CalculateBMI(weight: 123, height: 64);
            //However, a positional argument cannot follow a named argument.

            //must specify all but optional args
            TstArgs ta = new TstArgs(arg2: "abc", arg1: 124);
        }

        private static void ScopeAndDeclarationSpace()
        {
            //https://blogs.msdn.microsoft.com/ericlippert/2009/08/03/whats-the-difference-part-two-scope-vs-declaration-space-vs-lifetime/

            Utils.WriteSubTopic("Scope and Declaration Space");

            Utils.WriteDetailLine(string.Format("scope, class: {0}", z.ToString()));
            //class var, z or lang.z or fully qualified

            {
                int z = 2; // same name: z, new declaration space
                Utils.WriteDetailLine(string.Format("scope, class: {0}", z.ToString()));
                Utils.WriteDetailLine(string.Format("scope, class: {0}", Lang.z.ToString()));
                //or, this.z if instance

                //of course it is err to declare another z here in same declaration space
                //int z;
            }

            {
                int z = 3; //look another declaration space, z here too
                Utils.WriteDetailLine(string.Format("scope: {0}", z.ToString()));
            }
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

        //multiple assign
        private static void DeclareInitVariables()
        {
            Utils.WriteTopic("Var Declare Init");
//            Utils.WriteSubTopic("Declare and Init Variables");
            //ok            int a, b, c;  //declare only

//ok            int a, b, c = 0;  //only c is assigned, a and b are declared only

            //ok            int a =0, b = 1, c = 2;   //declare and assign

            int a, b, c;  //ok
            a = b = c = 0;  //ok
            Utils.WriteDetailLine(string.Format("a: {0} b: {1} c:{2}" , a.ToString(), b.ToString(), c.ToString()));

            ////////////////////////////
            int n = 3, m = 4, o = n + 1;  //can use prior var
            Utils.WriteDetailLine(string.Format("{0} {1} {2}", n, m, o));
        }
    }

    class TstArgs
    {
        public TstArgs(int arg1, string arg2, bool arg3 = true)
        {

        }
    }
}
