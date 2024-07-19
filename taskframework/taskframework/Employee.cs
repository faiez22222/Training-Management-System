using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace taskframework
{
    internal class Employee
    {
        public static void Main()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["devDB"].ConnectionString;
                //performOperation(connectionString);
                //GetEmployeesByDepartment(connectionString);
                Console.WriteLine("Enter Page Number");

                int pageNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Page Size");

                int pageSize = Convert.ToInt32(Console.ReadLine());
                GetEmployessPaged(connectionString, pageNumber, pageSize);


                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void performOperation(string connectionString)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                sql.Open();

               // for (int i = 10; i < 110; i++)
               // {
               //     using (SqlCommand insertCommand = new SqlCommand("insert into Employee values (@id, 'faiez', 'faiezmohd43@gmail.com', '1234567890')", sql))
               //     {
                 //       insertCommand.Parameters.Add(new SqlParameter("@id", i));
               //         int rowEffected = insertCommand.ExecuteNonQuery();
               //     }
              //  }
                SqlCommand command = new SqlCommand();

                using (SqlCommand selectCommand = new SqlCommand("select * from Employee", sql))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader[i]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                }


            }
        }
        public static void GetEmployeesByDepartment(string connectionString)
        {
            Console.WriteLine("Enter department");
            string department = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetEmployeesByDepartment" , connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Department" , department);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        Console.WriteLine($"ID: {reader["EmployeeId"]}, Name: {reader["Name"]}, Email: {reader["Email"]}, Department: {reader["Department"]}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No records found.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public static void GetEmployessPaged(string connectionString , int pageNumber , int pageSize)
        {

        }
    }
}
