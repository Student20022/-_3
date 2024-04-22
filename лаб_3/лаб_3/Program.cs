using System;
using MySql.Data.MySqlClient;

namespace BuildingSiteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;database=BuildingSiteDB;uid=root;password=mysqlshit";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to the database.");

                    // Выполнение запроса к таблице Suppliers
                    string query = "SELECT * FROM Suppliers";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Supplier_id\tSupplier_name\tAddress\tPhone\tManager_lastname");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetInt32(0)}\t{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetString(3)}\t{reader.GetString(4)}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
