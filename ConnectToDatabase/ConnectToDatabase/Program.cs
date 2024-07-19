using System;
using System.Data.SqlClient;

class Program
{
    static void main()
    {
        string connectionString = @"data source=DESKTOP-TIC5DM4\SQLEXPRESS;Database=ProgramDB;Integrated Security=SSPI;";
        string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Tables in the database:");
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["TABLE_NAME"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
