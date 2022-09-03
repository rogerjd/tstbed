using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * - can contain implementation(code body) (but, interface cant)
 */

namespace tstbed
{
    abstract class AbstractClass
    {
        public void Test()  //as long as not declared/marked abstract, can have methods/body
        {
            //can have body
        }

        public abstract void Test1();  //no body if declared abstract
    }
}
