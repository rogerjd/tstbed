using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Lang
{
    class interfaceTst : IEnumerable
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); //not recursion,  because explicitly implemented
        }


        IEnumerator GetEnumerator()
        {
            return null;
        }
    }
}
