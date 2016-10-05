using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * - can contain implementation(code body) (but, interface cant)
 */

namespace ConsoleApplication1
{
    abstract class AbstractClass1
    {
        public void Test()
        {
            //can have body
        }

        public abstract void Test1();  //no body if declared abstract
    }
}
