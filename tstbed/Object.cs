using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    static public class ObjectTst
    {
        static public void Test()
        {
            AnonymousObj();
        }

        static private void AnonymousObj()
        {
            var obj = new { name = "abc", num = 123 }; //needs prop name
            Utils.WriteDetailLine(obj.name + " " + obj.num);

            //also, see Linq
    //        var productQuery =
    //          from prod in products
    //          select new { prod.Color, prod.Price };  //takes name from property (products)
        }
    }
}
