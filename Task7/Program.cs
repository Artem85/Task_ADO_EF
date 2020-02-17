using System;
using Task7.Models.Repository;
using Task7.Interfaces;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EfDbContext context = new EfDbContext())
            {
                var dbContext = new EfDbContext();

                DbInitializer.Initialize(context);

                IRepository repository = new EfRepository(context);

                var suppliers = repository.SuppliersForCategory("Phone");
                Console.WriteLine("Phone Suppliers:");
                Console.WriteLine("----------------------------------");
                foreach (var supplier in suppliers)
                {
                    Console.WriteLine($"Supplier: {supplier.Name}\n" +
                                    $"\tCity: {supplier.City}");
                    //Console.WriteLine("----------------------------------");
                }

                var products = repository.ProductsForCategory("Phone");
                Console.WriteLine("");
                Console.WriteLine("Phones:");
                Console.WriteLine("----------------------------------");
                foreach (var product in products)
                {
                    Console.WriteLine($"Product: {product.Name}\n" +
                                    $"\tPrice: {product.Price}\n" +
                                    $"\tSupplier: {product.Supplier.Name}\n" +
                                    $"\tCity: {product.Supplier.City}");
                    //Console.WriteLine("----------------------------------");
                }

                products = repository.ProductsOfSupplier("Samsung");
                Console.WriteLine("");
                Console.WriteLine("Samsung Products:");
                Console.WriteLine("----------------------------------");
                foreach (var product in products)
                {
                    Console.WriteLine($"Product: {product.Name}\n" +
                                    $"\tCategory: {product.Category.Name}\n" +
                                    $"\tPrice: {product.Price}");
                    //Console.WriteLine("----------------------------------");
                }

                products = repository.ProductsByConditions(maxPrice: 600, supplierCity:"Seoul");
                Console.WriteLine("");
                Console.WriteLine("Products From Seoul whith price less than or equal 600:");
                Console.WriteLine("----------------------------------");
                foreach (var product in products)
                {
                    Console.WriteLine($"Product: {product.Name}\n" +
                                    $"\tCategory: {product.Category.Name}\n" +
                                    $"\tPrice: {product.Price}\n" +
                                    $"\tSupplier: {product.Supplier.Name}");
                    //Console.WriteLine("----------------------------------");
                }
            }

            Console.ReadKey();
        }
    }
}
