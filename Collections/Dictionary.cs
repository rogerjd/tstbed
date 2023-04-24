namespace tstbed.Collections
{
    static class DictionaryTester
    {
/* exceptions
    KeyNotFoundException - {tstDict["z"] if key "z" is not in dict

*/        
        static Dictionary<string, int> tstDict = new Dictionary<string, int>()
        {
            {"a", 1}, {"b", 2}
        };

        static public void Tester()
        {
            Console.WriteLine("dict");
            Create();
            Count();
            ContainsKey();  //Exists();
            Add(); // add Key, Value
            Remove(); //remove key (and of course its value)
            Update();
            Clear();
        }

        static void Create()
        {
            Console.WriteLine("create dict, see above");

            //oK tstDict = new Dictionary<string, int>();
        }

        static void Count()
        {
            Console.WriteLine($"Count {tstDict.Count}");

            //oK tstDict = new Dictionary<string, int>();
        }

        static void ContainsKey()
        {
            Console.WriteLine($"Exists, 'x' {tstDict.ContainsKey("x")}");
        }

        static void Add()
        {
            Count();
            Console.WriteLine("Add");
            tstDict.Add("c", 3);
            Count();
        }

        static void Remove()
        {
            Count();
            Console.WriteLine("Remove");
            tstDict.Remove("c"); //returns bool (its value is as you'd expect)
            Count();
        }

        static void Update()
        {
            Console.WriteLine($"Update a {tstDict["a"]}");
            tstDict["a"] = 123;
            Console.WriteLine($"Updated {tstDict["a"]}");
        }

        static void Clear()
        {
            Console.WriteLine("Clear");
            Count();
            tstDict.Clear();
            Count();
        }        
    }
};