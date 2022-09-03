﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    class ObjectAndCollectionInitializers
    {
        //w/the initializer {}, the () after new is optional; else required
        Product prod = new Product() { ProductID = 100, Description = "test desc" };
        Product prod2 = new Product(); //these are props, not ctor args:(200, "name", "desc", 12.23, "catg");

        string[] stringArray = { "apple", "orange", "plum" };  //array initializer, doesnt need (optional) new()

        List<int> intList = new List<int> { 10, 20, 30, 40 };

        Dictionary<string, int> myDict = new Dictionary<string, int>
        {
            {"apple", 10 },
            {"orange", 20 },
            {"plum", 30 }
        };

        Dictionary<string, int> myNewDict = new Dictionary<string, int>()
        {
            ["abc"] = 123,
            ["def"] = 789
        };
    }
} 
