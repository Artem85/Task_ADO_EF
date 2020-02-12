using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.Models.Repository
{
    class Repository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Category> Categories
        {
            get { return context.Categories; }
        }
        public IEnumerable<Supplier> Suppliers
        {
            get { return context.Suppliers; }
        }
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
