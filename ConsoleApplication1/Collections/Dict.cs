﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Collections
{
    static class Dict
    {
        static Dictionary<string, string> dict = new Dictionary<string, string> { ["abc"] = "123" }; //ref: or {{"k", "v"}}

        public static void Test()
        {
            Console.WriteLine("Dictionary ****");
            Loop();
            count();
            ItemPropIndexer_GetSet();
            Add();
            ContainsKey();
            ContainsValue();
        }

        private static void ContainsKey()
        {
            Console.WriteLine("ContainsKey **");

            Console.WriteLine(dict.ContainsKey("abc"));

            Console.WriteLine(dict.ContainsKey("noKey"));
        }

        private static void ContainsValue()
        {
            Console.WriteLine("ContainsValue **");

            Console.WriteLine(dict.ContainsValue("456")); //was changed by now

            Console.WriteLine(dict.ContainsValue("321 not found"));
        }

        private static void Add()
        {
            Console.WriteLine("Indexer **");

            //ok
            dict.Add("notExist", "ok");

            //err:  ArgumentException
            //  however, indexer allows this(key already exists, not an error)
            try
            {
                dict.Add("notExist", "cant add if key exists");
            }
            catch (Exception)
            {
                Console.WriteLine("Key already exists on Add, it is err");
            }
        }

        private static void ItemPropIndexer_GetSet()
        {
            //refL Item is indexer (see docs: this[key]), cant use Item
            //            Console.WriteLine(dict.Item["abc"]);
            Console.WriteLine("Indexer **");
            
            //key exists:
            Console.WriteLine(dict["abc"]);

            //key does not exist:  KeyNotFoundException
            try
            {
                Console.WriteLine(dict["zzz"]);
            }
            catch (Exception)
            {
                Console.WriteLine("Key \"zzz\", not found");
            }

            //replace existing
            dict["abc"] = "456";
            Console.WriteLine("count: {0}, {1}", dict.Count, dict["abc"]);

            //add new
            dict["def"] = "789";
            Console.WriteLine("count: {0}, {1} {2}", dict.Count, dict["abc"], dict["def"]);
            Loop();
        }

        private static void count()
        {
            Console.WriteLine("count **");
            Console.WriteLine(dict.Count);
        }

        static void Loop()
        {
            Console.WriteLine("Loop **");
            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }
        }
    }
}