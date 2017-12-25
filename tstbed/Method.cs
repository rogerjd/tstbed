using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Method
    {
        static public void Test()
        {
            Params();
        }

        private static void Params()
        {
            int n = 3;
            val_param(n);
            Console.WriteLine("Val should be 3(unchanged): {0} ", n);

            int m;
            //must assign before use, else compiler error
            m = 4;
            ref_param(ref m);
            Console.WriteLine("Val should be 5 (4 + 1): {0}", m);

            int i;
            //can pass unassigned; like ref(pass by ref), but input can be unassigned
            out_param(out i);
            int x = 3; //does not discard input
            out_param(out x);
            Console.WriteLine("Val should be 8: {0}", i);

            params_param();
            params_param(1, 2, 3);
            params_param(new int[]{ 4, 5, 6, 7});
        }

        private static void out_param(out int i)
        {
            //pass by ref
            //does not discard input
            //must assign before leaving method
            i = 8;
        }

        private static void ref_param(ref int m)
        {
            m++;
        }

        private static void val_param(int n)
        {
            n = n * 2;
        }

        /*
        params key word means OPTIONAL parameters that can be passed or not to the Method. (0 or more)
        An array with out params key word means you MUST pass array argument to the method. (1 or more)
        With params you can call your method like this:

        addTwoEach(1, 2, 3, 4, 5);
        Without params, you can’t.

        Additionally, you can call the method with an array as a parameter in both cases:

        addTwoEach(new int[] { 1, 2, 3, 4, 5 });
        That is, params allows you to use a shortcut when calling the method.
        */

        private static void params_param(params int[] args)
        {
            Console.WriteLine("Length of params array: {0}", args.Length);
        }
    }
}
