using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    public delegate int MyDel(string s);

    class Delegates
    {
        public Delegates()
        {
            tst(Tst.md);
            tst(Tst.DelMeth2);

            MyDel x = Tst.DelMeth;
            x("qwe");

            tst(z => 3); //lambda
        }

        private void tst(MyDel md)
        {
            int n = md("anv");
            Console.WriteLine("Delegate return value: {0}", n);
        }
    }


    static class Tst
    {
        static public readonly MyDel md = DelMeth;

        public static int DelMeth(string x)
        {
            Console.WriteLine(x);
            return 1;
        }

        public static int DelMeth2(string s)
        {
            s = s.ToUpper();
            Console.WriteLine(s);
            return 2;
        }
    }
}
