using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    //named properties allowed in contstructor, but only for attributes
    //  ie: ctor defined with 1 param: ctor(int n), but can call like this:
    //  ctor(3, Prop1="abc", Prop2="def"   the props must be in the class, but
    //  they are not in the ctor params
    class Attribute
    {
    }
}
