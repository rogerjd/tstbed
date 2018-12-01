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
    public class ProductComparer : EqualityComparer<Product>
    {
        public override bool Equals(Product x, Product y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null || y is null)
            {
                return false;
            }

            return y.Code != x.Code;
        }

        public override int GetHashCode(Product obj)
        {
            throw new NotImplementedException();
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
                                new Product {Name="orange", Code=4 } }; //,
                                                                        //new Product {Name="tst", Code=3} }; //must have same number of elements to equal

            bool SeqEqual = storeA.SequenceEqual(storeB); //default without Equals method specified is reference equality (that is behavior for object.Equals (ref eq))
            Utils.WriteDetailLine($"Result {SeqEqual}");  //implement Equals or IEquatable to compare values; IEqualtiyCompare is alt way to compare

            SeqEqual = storeA.SequenceEqual(storeB, new ProductComparer()); //default without Equals method specified is reference equality (that is behavior for object.Equals (ref eq))
            Utils.WriteDetailLine($"Result {SeqEqual}");  //implement Equals or IEquatable to compare values; IEqualtiyCompare is alt way to compare
        }
    }
}
