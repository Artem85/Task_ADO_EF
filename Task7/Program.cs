using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Task7.Data_Access;
using Task7.Models;
using Task7.Models.Repository;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            string adoConnectionString = ConfigurationManager.ConnectionStrings["ADOConnection"].ConnectionString;

            //using (SqlConnection connection = new SqlConnection(adoConnectionString))
            //{
            //    connection.Open();
            //    Console.WriteLine("Connection is opened");

            //    Console.WriteLine("\tConnectionString: {0}", connection.ConnectionString);
            //    Console.WriteLine("\tDatabase: {0}", connection.Database);
            //    Console.WriteLine("\tDataSource: {0}", connection.DataSource);
            //    Console.WriteLine("\tServerVersion: {0}", connection.ServerVersion);
            //    Console.WriteLine("\tState: {0}", connection.State);
            //    Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);
            //}
            //Console.WriteLine("Connection is closed");

            //var categoryGataway = new CategoryGateway(adoConnectionString);

            //categoryGataway.Insert(new Category { Name = "Laptop"});

            //var selCat = categoryGataway.SelectAll();

            var efRepository = new Repository();
            IEnumerable<Category> cats = efRepository.Categories;

            foreach (Category cat in cats)
            {
                Console.WriteLine($"CategoryId = {cat.CategoryId}, Name '{cat.Name}'");
            }

            Console.ReadKey();
        }
    }
}
