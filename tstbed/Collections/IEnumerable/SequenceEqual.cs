using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Collections
{
    public class Product
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Product prod))
            {
                return false;
            }

            return prod.Name == this.Name;
        }
    }

    static class SequenceEqual
    {
        public static void Test()
        {
            Utils.WriteTopic("Collections");
            Utils.WriteSubTopic("Sequence Equal");
            Product[] storeA = { new Product {Name="apple", Code=9 },
                                new Product{Name="orange", Code=4 } };
            Product[] storeB = { new Product {Name="apple", Code=9 },
                                new Product{Name="orange", Code=4 } };

            bool SeqEqual = storeA.SequenceEqual(storeB); //default with Equals method specified is reference equality
            Utils.WriteDetailLine($"Result {SeqEqual}");
        }
    }
}
