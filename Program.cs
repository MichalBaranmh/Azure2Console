using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string to your Azure SQL Database
        string connectionString = "Server=tcp:uczelniamichalbaran.database.windows.net,1433;Initial Catalog=uczelniaMichalBaran;Persist Security Info=False;User ID=SuperMichal;Password= ***HASLO*** !_;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        string query = "SELECT * FROM SalesLT.ProductModel";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ProductModelID: {reader["ProductModelID"]}, Name: {reader["Name"]}, CatalogDescription: {reader["CatalogDescription"]}, ModifiedDate: {reader["ModifiedDate"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                }
            }
        }
    }
}
