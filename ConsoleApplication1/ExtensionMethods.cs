using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class MyExtensionMethods
    {
        public static decimal TotalPrices(this ShoppingCart cartParam)
        {
            decimal total = 0;
            foreach (Product prod in cartParam.Products)
            {
                total += prod.Price;
            }
            return total;
        }

        //this is more genl, will work w/array and List
        public static decimal TotalPricesWithIEnumerable(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;
            foreach (Product prod in productEnum)
            {
                total += prod.Price;
            }
            return total;
        }

        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> productEnum, string categoryParam)
        {
            foreach(Product prod in productEnum)
            {
                if (prod.Category == categoryParam)
                {
                    yield return prod;
                }
            }
        }
    }

    class ExtensionMenthods
    {
        public static void Test()
        {
            ShoppingCart cart = new ShoppingCart()
            {
                Products = new List<Product>
                {
                   new Product {Description = "Kayak", Price = 275M, Category = "Watersports" },
                   new Product {Description = "Lifejacket", Price = 48.95M, Category = "Watersports" },
                   new Product {Description = "Soccer ball", Price = 19.50M, Category = "Soccer"  },
                   new Product {Description = "Corner flag", Price = 34.95M, Category = "Soccer"  }
                }
            };

            decimal cartTotal = cart.TotalPrices();
            Console.WriteLine("Cart Total: {0:c}", cartTotal);

            IEnumerable<Product> products = cart;
            cartTotal = products.TotalPricesWithIEnumerable();
            Console.WriteLine("Cart Total: {0:c}", cartTotal);

            Product[] productArray = {
                   new Product {Description = "Kayak", Price = 275M },
                   new Product {Description = "Lifejacket", Price = 48.95M},
                   new Product {Description = "Soccer ball", Price = 19.50M },
                   new Product {Description = "Corner flag", Price = 34.95M }
            };
            cartTotal = productArray.TotalPricesWithIEnumerable();
            Console.WriteLine("Cart Total: {0:c}", cartTotal);

            foreach (Product prod in cart.FilterByCategory("Soccer") )
            {
                Console.WriteLine("Name: {0}  Price: {1}", prod.Description, prod.Price);
            }

            //              returns IEnumerable
            decimal total = cart.FilterByCategory("Soccer").TotalPricesWithIEnumerable();
            Console.WriteLine("Total: {0} for Soccer items", total);
        }
    }
}