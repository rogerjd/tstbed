using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ObjectAndCollectionInitializers
    {
        //w/the initializer {}, the () after new is optional; else required
        Product prod = new Product() { ProductID = 100 };

        string[] stringArray = { "apple", "orange", "plum" };  //array initializer, doesnt need (optional) new()

        List<int> intList = new List<int> { 10, 20, 30, 40 };

        Dictionary<string, int> myDict = new Dictionary<string, int>
        {
            {"apple", 10 },
            {"orange", 20 },
            {"plum", 30 }
        };
    }
}
