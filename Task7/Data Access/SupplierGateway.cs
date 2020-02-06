﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Task7.Common;

namespace Task7.Data_Access
{
    class SupplierGateway : IDataGateway<Supplier>
    {
        private readonly string connString = ConfigurationManager.ConnectionStrings["ADOConnection"].ConnectionString;

        public void Delete(Supplier item)
        {
            string query = "DELETE FROM Supplier WHERE SupplieryId = @id";
            int id = item.SupplierId;
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                int resultNum = command.ExecuteNonQuery();
                if (resultNum == 1)
                {
                    Console.WriteLine($"Supplier {item.Name} has been deleted.");
                }
                else
                {
                    Console.WriteLine($"Unable to delete Supplier {item.Name}");
                }
            }
        }

        public void Insert(Supplier item)
        {
            string query = "INSERT INTO Supplier VALUES (@name)";
            string name = item.Name;

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                var nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);

                int resultNum = command.ExecuteNonQuery();
                if (resultNum == 1)
                {
                    Console.WriteLine($"Supplier {item.Name} has been inserted.");
                }
                else
                {
                    Console.WriteLine($"Unable to insert Supplier {item.Name}");
                }
            }
        }

        public IEnumerable<Supplier> SelectAll()
        {
            var retVal = new List<Supplier>();
            string query = "SELECT * FROM Supplier";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    retVal.Add(new Supplier()
                    {
                        SupplierId = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
                reader.Close();
            }

            return retVal;
        }

        public Supplier SelectById(int id)
        {
            var retVal = new Supplier();
            string query = "SELECT * FROM Supplier WHERE SupplierId = @id";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);
                var idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    retVal = new Supplier()
                    {
                        SupplierId = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                }

                reader.Close();
            }

            return retVal;
        }

        public void Update(Supplier item)
        {
            string query = "UPDATE Supplier SET Name = @name WHERE SupplierId = @id";
            int id = item.SupplierId;
            string name = item.Name;

            using (var connection = new SqlConnection(connString))
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
                    Console.WriteLine($"Supplier {item.Name} has been updated.");
                }
                else
                {
                    Console.WriteLine($"Unable to update Supplier {item.Name}");
                }
            }
        }
    }
}
