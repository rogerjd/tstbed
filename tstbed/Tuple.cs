using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    class TupleTst
    {
        public static void Test()
        {
            Utils.WriteTopic("Tuple");
            Demo();
            Compare();
            Named();
        }

        private static void Named()
        {
//need >net 4.7            (string name, int id) x = ("H", 2);
        }

        private static void Demo()
        {
            Utils.WriteSubTopic("Demo");
            var t1 = Tuple.Create(1, "foo");
            Utils.WriteDetailLine(t1.Item1.ToString());
            Utils.WriteDetailLine(t1.Item2);
        }

        public static void Compare()
        {
            Utils.WriteSubTopic("Compare");
            var t1 = Tuple.Create(1, "foo");
            var t2 = Tuple.Create(1, "foo");
            //structural comparison is default for tuple
            Utils.WriteDetailLine(t1.Equals(t2).ToString());
            Utils.WriteDetailLine((t1 == t2).ToString());

            IStructuralEquatable se1 = t1;
            bool isTrue = se1.Equals(t2, StringComparer.InvariantCultureIgnoreCase);
            isTrue = se1.Equals(t2);

            IStructuralComparable sc1 = t1;
            int zero = sc1.CompareTo(t2, StringComparer.InvariantCultureIgnoreCase);
            Utils.WriteDetailLine(zero.ToString());
        }
    }
}
