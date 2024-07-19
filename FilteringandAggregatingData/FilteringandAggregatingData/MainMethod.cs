using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringandAggregatingData
{
    public class MainMethod
    {
        public static void Main()
        {
            List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", Category = "Electronics", Price = 1200.99, Stock = 10 },
            new Product { ProductId = 2, ProductName = "Smartphone", Category = "Electronics", Price = 799.99, Stock = 5 },
            new Product { ProductId = 3, ProductName = "Tablet", Category = "Electronics", Price = 499.99, Stock = 3 },
            new Product { ProductId = 4, ProductName = "Headphones", Category = "Accessories", Price = 199.99, Stock = 15 },
            new Product { ProductId = 5, ProductName = "Monitor", Category = "Electronics", Price = 299.99, Stock = 7 },
            new Product { ProductId = 6, ProductName = "Mouse", Category = "Accessories", Price = 49.99, Stock = 25 },
            new Product { ProductId = 7, ProductName = "Keyboard", Category = "Accessories", Price = 79.99, Stock = 18 },
            new Product { ProductId = 8, ProductName = "Chair", Category = "Furniture", Price = 149.99, Stock = 20 },
            new Product { ProductId = 9, ProductName = "Desk", Category = "Furniture", Price = 249.99, Stock = 5 },
            new Product { ProductId = 10, ProductName = "USB Cable", Category = "Accessories", Price = 9.99, Stock = 50 }
        };

            var electronicsProducts = from product in products
                          where product.Category == "Electronics"
                          select product.ProductName;
            var electronicProductMethod = products.Where(product => product.Category == "Electronics").
                Select(product=>product.ProductName);
            foreach (var name in electronicProductMethod)
            {
                Console.WriteLine(name);
            }

            var stock = from product in products
                        where product.Stock < 5
                        select new { product.ProductName, product.Stock };
            var stockMethod = products.Where(products => products.Stock<5).Select(product =>new { product.ProductName, product.Stock });  
            foreach (var name in stockMethod)
            {
                Console.WriteLine(name);
            }


            var totalStockValue = products.Sum(product => product.Stock*product.Price);
            Console.WriteLine("Toalal Value " + totalStockValue);

            var mostExpensiveProduct = products.Max(products => products.Price);
            Console.WriteLine("Expensive Value " + mostExpensiveProduct);

            var groupProductByCategory = products.GroupBy(products => products.Category).Select(productGroup=> new { Category=productGroup.Key , Count = productGroup.Count()});
            foreach (var name in groupProductByCategory)
            {
                Console.WriteLine(name);
            }
            var averageByCategory = products.GroupBy(products => products.Category).Select(productGroup => new {Category = productGroup.Key , AveragePrice = productGroup.Average(p=>p.Price) });
            foreach (var name in averageByCategory)
            {
                Console.WriteLine(name);
            }



        }
    }
}
