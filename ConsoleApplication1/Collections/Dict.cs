using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Collections
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
            ContainsKey();
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

    class Customer
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

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
