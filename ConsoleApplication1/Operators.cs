using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Operators
    {
        public static void Test()
        {
            LogicalAndConditionalLogicalOperators();
        }

        private static void LogicalAndConditionalLogicalOperators()
        {
            //logical: |  &
            //conditional: ||  &&   these short-circuit (logical ones dont)
            //either can be used on boolean expressions
            //func calls, exceptions, etc and short-circuit

            bool a = true, b = false;
            bool result = a | b;
            result = a || b;
            result = a & b;
            result = a && b;

            int n = 0, m;
            result = a || ((3 / n) == 1);  //will not throw exception, due to short-circuit
            result = a | ((3 / n) == 1);   //will throw exception, does not short-circuit
        }
    }
}
