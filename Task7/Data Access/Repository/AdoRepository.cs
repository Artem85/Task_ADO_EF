using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7.Interfaces;
using Task7.Models;

namespace Task7.Data_Access.Repository
{
    class AdoRepository : IRepository
    {
        public IEnumerable<Product> ProductsByConditions(decimal minPrice, decimal maxPrice, string supplierCity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> ProductsForCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> ProductsOfSupplier(string supplier)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> SuppliersForCategory(string category)
        {
            throw new NotImplementedException();
        }
    }
}
