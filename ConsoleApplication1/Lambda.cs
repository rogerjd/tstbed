using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //see ExtensionMethods for examples

    /*
     * 1 - can call func  p => MyFunc(p)
     * 2 - can have multiple params (if Func<> allows), enclose in parentheses
     *      (prod, count) => prod.Price >= 20  && count > 0
     * 3 - can have multiple statements, use braces and return
     *      p => {
     *          ....
     *          ....
     *          return;
     *      }
     */
    class Lambda
    {
    }
}
