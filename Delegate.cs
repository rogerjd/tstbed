using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    public delegate int MyDel(string s);
    delegate int MyDel2(string s);


    class Delegates
    {
        public int NumEntries { get; } // example of a property, can only read, can be written in ctor
        public Delegates()
        {
            NumEntries = 3;

            MyDel md; //this caused warning\errir = null;
            md = Tst.DelMeth;
            tst(md);
            md = Tst.DelMeth2;

            tst(Tst.md);       //cant change del type
            tst(Tst.DelMeth2); //can use compatible method

            MyDel x = Tst.DelMeth;
            x("qwe");

            tst(z => 3); //lambda
            tst((string z) =>
            {
                Console.WriteLine(z);
                return 3;
            }); //lambda            
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
