using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Collections
{
    /* IEquatable - used in Dictionary to determine Equality (key), not default reference
     *              semantics(2 diff objs not equal(addr), but w/IE can be equal(flds))
     * 
     */

    static class Dict
    {
        static Dictionary<string, string> dict = new Dictionary<string, string> { ["abc"] = "123" }; //ref: or {{"k", "v"}}

        public static void Test()
        {
            Utils.WriteTopic("Dictionary");
            Loop();
            count();
            ItemPropIndexer_GetSet();
            Add();
            ContainsKey();  // key => bool
            ContainsValue();
            Equality();
        }

        private static void Equality()
        {
            Utils.WriteSubTopic("Equality");
            Customer c1 = new Customer("Bloggs", "Joe");
            Customer c2 = new Customer("Bloggs", "Joe");

            //not equal
            Utils.WriteDetailLine((c1 == c2).ToString());
            Utils.WriteDetailLine((c1.Equals(c2)).ToString());

            //same rules apply for Dict
            Dictionary<Customer, string> d = new Dictionary<Customer, string>();
            d[c1] = "Joe";
            Utils.WriteDetailLine(d.ContainsKey(c2).ToString());

            //use custom equality comparer
            var CustomerComparer = new CustomerComparer();
            d = new Dictionary<Customer, string>(CustomerComparer);
            d[c1] = "Joe";
            Utils.WriteDetailLine(d.ContainsKey(c2).ToString());
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
            Console.WriteLine("Add **");

            //each Key must be unique. If need duplicate keys use, for instance: you can use Lookup<TKey, TValue> instead of dictionary.
            // W, add key,  will get exception if already exist ArgumentException 
            //R,              "     "    "     if doesnt exist  KeyNotFoundException
            //ok
            dict.Add("notExist", "ok");

            //err:  ArgumentException
            try
            {
                dict.Add("notExist", "cant add if key exists");
            }
            catch (Exception)
            {
                Console.WriteLine("if Key already exists on Add, then it is err");
            }

            dict["notExist"] = "replace value for existing key";
        }

        private static void ItemPropIndexer_GetSet()
        {
            Console.WriteLine("Indexer **");

            //key exists:
            //ref: Item is indexer (see docs: this[key]), cant use Item
            //Console.WriteLine(dict.Item["abc"]);
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

    class Customer
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="ln">Last Name</param>
        /// <param name="fn">First Name</param>
        public Customer(string ln, string fn)
        {
            LastName = ln;
            FirstName = fn;
        }
    }

    class CustomerComparer : EqualityComparer<Customer>
    {
        public override bool Equals(Customer x, Customer y)
            => x.LastName == y.LastName && x.FirstName == y.FirstName;

        public override int GetHashCode(Customer obj)
            => (obj.LastName + ";" + obj.FirstName).GetHashCode();
    }
}
