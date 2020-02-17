using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7.Interfaces;

namespace Task7.Models.Repository
{
    class EfRepository : IRepository
    {
        private EfDbContext context;

        public EfRepository(EfDbContext context)
        {
            this.context = context;
        }

        IEnumerable<Product> IRepository.ProductsForCategory(string category)
        {
            return context.Products
                            .Include("Category")
                            .Include("Supplier")
                            .Where(p => p.Category.Name == category)
                            .ToList();
        }

        IEnumerable<Supplier> IRepository.SuppliersForCategory(string category)
        {
            return context.Products
                        .Include("Category")
                        .Include("Supplier")
                        .Where(p => p.Category.Name == category)
                        .Select(p => p.Supplier)
                        .ToList();
        }

        IEnumerable<Product> IRepository.ProductsOfSupplier(string supplier)
        {
            return context.Products
                            .Include("Category")
                            .Include("Supplier")
                            .Where(p => p.Supplier.Name == supplier)
                            .ToList();
        }

        IEnumerable<Product> IRepository.ProductsByConditions(decimal minPrice, decimal maxPrice, string supplierCity)
        {
            return context.Products
                            .Include("Category")
                            .Include("Supplier")
                            .Where(p => supplierCity == "" || p.Supplier.City == supplierCity)
                            .Where(p => minPrice == 0 || p.Price >= minPrice)
                            .Where(p => maxPrice == 0 || p.Price <= maxPrice)
                            .ToList();
        }

    }
}
