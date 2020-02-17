using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7.Models;

namespace Task7.Interfaces
{
    interface IRepository
    {
        IEnumerable<Product> ProductsForCategory(string category);
        IEnumerable<Supplier> SuppliersForCategory(string category);
        IEnumerable<Product> ProductsOfSupplier(string supplier);
        IEnumerable<Product> ProductsByConditions(decimal minPrice = 0, decimal maxPrice = 0, string supplierCity = "");
    }
}
