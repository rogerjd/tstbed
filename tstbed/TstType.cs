using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }

    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void UpdateProduct(Product product);
    }

    interface IPriceReducer
    {
        void ReducePrices(decimal priceReduction);
    }

    public class FakeRepository : IProductRepository
    {
        Product[] products = ProductData.Get();

        public int UpdateProductCallCount { get; private set; }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product productParam)
        {
            foreach (Product p in products
                .Where(e => e.Name == productParam.Name)
                .Select(e => e))
            {
                p.Price = productParam.Price;
            }
            UpdateProductCallCount++;
        }

        public decimal GetTotalValue()
        {
            return products.Sum(p => p.Price);
        }
    }

    public class MyPriceReducer : IPriceReducer
    {
        IProductRepository repository;

        public MyPriceReducer(IProductRepository repo)
        {
            repository = repo;
        }

        public void ReducePrices(decimal priceReduction)
        {
            foreach (Product p in repository.GetProducts())
            {
                p.Price = Math.Max(1, p.Price - priceReduction);
                
                //repository.UpdateProduct(p); //i dont think this is necessary for price
            }
        }
    }

    public interface IIValueCalculator
    {
        decimal ValueProducts(params Product[] products);
    }

    class LinqValueCalculator : IIValueCalculator
    {
        IDiscountHelper discounter;

        public LinqValueCalculator(IDiscountHelper disoucntParam)
        {
            discounter = disoucntParam;
        }

        public decimal ValueProducts(params Product[] products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }

    interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }

    class DefaultDiscountHelper : IDiscountHelper
    {
        decimal DiscountRate { get; set; }  //ref: can use property injection (must be public)

        public DefaultDiscountHelper(decimal discountParam)
        {
            DiscountRate = discountParam;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (DiscountRate / 100M * totalParam));
        }
    }

    public class ShoppingCart : IEnumerable<Product>
    {
        public List<Product> Products { get; set; }
        private IIValueCalculator calculator;

        public ShoppingCart(IIValueCalculator calcParam)
        {
            calculator = calcParam;
        }

        /*
                public ShoppingCart()
                {

                }
        */

        public decimal CalculateStockValue()
        {
            Product[] products = ProductData.Get();
            decimal totalValue = calculator.ValueProducts(products);
            return totalValue;
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    static class ProductData
    {
        public static Product[] Get()
        {
            Product[] products =
{
                new Product {Name="Kayak", Price=275M },
                new Product {Name="Lifejacket", Price=48.95M },
                new Product {Name="Soccer ball", Price=19.50M },
                new Product {Name="Stadium", Price=79500M}
            };
            return products;
        }
    }
}
