using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Task7.Common;

namespace Task7.Data_Access
{
    class ProductGateway : IDataGateway<Product>
    {
        private readonly string connString = ConfigurationManager.ConnectionStrings["ADOConnection"].ConnectionString;

        public void Delete(Product item)
        {
            string query = "DELETE FROM Product WHERE ProductId = @id";
            int id = item.ProductId;
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                int resultNum = command.ExecuteNonQuery();
                if (resultNum == 1)
                {
                    Console.WriteLine($"Product {item.Name} has been deleted.");
                }
                else
                {
                    Console.WriteLine($"Unable to delete Product {item.Name}");
                }
            }
        }

        public void Insert(Product item)
        {
            string query = "INSERT INTO Product VALUES (@name, @creationDate, @categoryId, @supplierId, @price)";
            string name = item.Name;
            DateTime creationDate = item.CreationDate;
            int categoryId = item.CategoryId;
            int supplierId = item.SupplierId;
            decimal price = item.Price;

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);

                var nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                var creationDateParam = new SqlParameter("@creationDate", creationDate);
                command.Parameters.Add(creationDateParam);
                var categoryIdParam = new SqlParameter("@categoryId", categoryId);
                command.Parameters.Add(categoryIdParam);
                var supplierIdParam = new SqlParameter("@supplierId", supplierId);
                command.Parameters.Add(supplierIdParam);
                var priceParam = new SqlParameter("@price", price);
                command.Parameters.Add(priceParam);

                int resultNum = command.ExecuteNonQuery();
                if (resultNum == 1)
                {
                    Console.WriteLine($"Product {item.Name} has been inserted.");
                }
                else
                {
                    Console.WriteLine($"Unable to insert Product {item.Name}");
                }
            }
        }

        public IEnumerable<Product> SelectAll()
        {
            var retVal = new List<Product>();
            string query = "SELECT * FROM Product";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    retVal.Add(new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        CreationDate = reader.GetDateTime(2),
                        CategoryId = reader.GetInt32(3),
                        SupplierId = reader.GetInt32(4),
                        Price = reader.GetDecimal(5)
                    });
                }
                reader.Close();
            }

            return retVal;
        }

        public Product SelectById(int id)
        {
            var retVal = new Product();
            string query = "SELECT * FROM Product WHERE ProductId = @id";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    retVal = new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        CreationDate = reader.GetDateTime(2),
                        CategoryId = reader.GetInt32(3),
                        SupplierId = reader.GetInt32(4),
                        Price = reader.GetDecimal(5)
                    };
                }

                reader.Close();
            }

            return retVal;
        }

        public void Update(Product item)
        {
            string query = "UPDATE Product " +
                            "SET Name = @name," +
                            "CreationDate = @creationDate" +
                            "CategoryId = @categoryId" +
                            "SupplierId = @supplierId" +
                            "Price = @price" +
                            "WHERE ProductId = @id";
            int id = item.SupplierId;
            string name = item.Name;
            DateTime creationDate = item.CreationDate;
            int categoryId = item.CategoryId;
            int supplierId = item.SupplierId;
            decimal price = item.Price;

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);

                var nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                var creationDateParam = new SqlParameter("@creationDate", creationDate);
                command.Parameters.Add(creationDateParam);
                var categoryIdParam = new SqlParameter("@categoryId", categoryId);
                command.Parameters.Add(categoryIdParam);
                var supplierIdParam = new SqlParameter("@supplierId", supplierId);
                command.Parameters.Add(supplierIdParam);
                var priceParam = new SqlParameter("@price", price);
                command.Parameters.Add(priceParam);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                int resultNum = command.ExecuteNonQuery();
                if (resultNum == 1)
                {
                    Console.WriteLine($"Product {item.Name} has been updated.");
                }
                else
                {
                    Console.WriteLine($"Unable to update Product {item.Name}");
                }
            }
        }
    }
}
