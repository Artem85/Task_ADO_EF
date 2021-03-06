﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Task7.Models;

namespace Task7.Data_Access
{
    class CategoryGateway : IDataGateway<Category>
    {
        private readonly string connectionString;
        
        public CategoryGateway(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Delete(Category item)
        {
            string query = "DELETE FROM Categories WHERE CategoryId = @id";
            int id = item.CategoryId;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                int resultNum = command.ExecuteNonQuery();
                if (resultNum == 1)
                {
                    Console.WriteLine($"Category {item.Name} has been deleted.");
                }
                else
                {
                    Console.WriteLine($"Unable to delete Category {item.Name}");
                }
            }
        }

        public void Insert(Category item)
        {
            string query = "INSERT INTO Categories VALUES (@name)";
            string name = item.Name;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                var nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);

                int resultNum = command.ExecuteNonQuery();
                if (resultNum == 1)
                {
                    Console.WriteLine($"Category {item.Name} has been inserted.");
                }
                else
                {
                    Console.WriteLine($"Unable to insert Category {item.Name}");
                }
            }
        }

        public IEnumerable<Category> SelectAll()
        {
            var retVal = new List<Category>();
            string query = "SELECT * FROM Categories";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    retVal.Add(new Category()
                    {
                        CategoryId = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
                reader.Close();
            }

            return retVal;
        }

        public Category SelectById(int id)
        {
            var retVal = new Category();
            string query = "SELECT * FROM Categories WHERE CategoryId = @id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    retVal = new Category()
                    {
                        CategoryId = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                }

                reader.Close();
            }

            return retVal;
        }

        public void Update(Category item)
        {
            string query = "UPDATE Categories SET Name = @name WHERE CategoryId = @id";
            int id = item.CategoryId;
            string name = item.Name;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                var nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                int resultNum = command.ExecuteNonQuery();
                if (resultNum == 1)
                {
                    Console.WriteLine($"Category {item.Name} has been updated.");
                }
                else
                {
                    Console.WriteLine($"Unable to update Category {item.Name}");
                }
            }
        }
    }
}
