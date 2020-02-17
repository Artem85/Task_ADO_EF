using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.Models.Repository
{
    public static class DbInitializer
    {
        public static void Initialize(EfDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            var newCategories = new List<Category> {
                new Category { Name = "TV" },
                new Category { Name = "Phone" },
                new Category { Name = "Laptop" }
            };
            newCategories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var newSuppliers = new List<Supplier> {
                new Supplier { Name = "Apple", City = "San Francisco"},
                new Supplier { Name = "Samsung", City = "Seoul" },
                new Supplier { Name = "Electron", City = "Seoul" }
            };
            newSuppliers.ForEach(s => context.Suppliers.Add(s));
            context.SaveChanges();

            var newProducts = new List<Product> {
                new Product { Name = "IPhone", CategoryId = 2, SupplierId = 1, CreationDate = DateTime.Today, Price = 500 },
                new Product { Name = "Galaxy", CategoryId = 2, SupplierId = 2, CreationDate = DateTime.Today, Price = 400 },
                new Product { Name = "MacBook", CategoryId = 3, SupplierId = 1, CreationDate = DateTime.Today, Price = 1000 },
                new Product { Name = "Samsung TV", CategoryId = 1, SupplierId = 2, CreationDate = DateTime.Today, Price = 600 },
                new Product { Name = "Simple TV", CategoryId = 1, SupplierId = 3, CreationDate = DateTime.Today, Price = 200 },
                new Product { Name = "Samsung Laptop", CategoryId = 3, SupplierId = 2, CreationDate = DateTime.Today, Price = 800 }
            };
            newProducts.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}
