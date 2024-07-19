using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToDatabase
{
    internal class transaction
    {
        public static void Main()
        {
            string connectionString = @"data source=DESKTOP-TIC5DM4\SQLEXPRESS;Database=ProgramDB;Integrated Security=SSPI;";
            PerformTransaction(connectionString);
        }
        public static void PerformTransaction(string connectionString)
        {
            string insertAccountDetails = "INSERT INTO Account_Details (accountId, Account_type, Account_Number, Available_Balance) VALUES (@accountId, @Account_type, @Account_Number, @Available_Balance);";
            string insertCreditHistory = "INSERT INTO Credit_History (id, accountnumber, Balance_Credit, creation_Time) VALUES (@id, @accountnumber, @Balance_Credit, @creation_Time);";
            string insertDebitHistory = "INSERT INTO Debit_History (id, accountnumber, Balance_Debit, creation_Time) VALUES (@id, @accountnumber, @Balance_Debit, @creation_Time);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                    try
                    {
                        // Insert into Account_Details
                        command.CommandText = insertAccountDetails;
                        command.Parameters.AddWithValue("@accountId", 1);
                        command.Parameters.AddWithValue("@Account_type", "Savings");
                        command.Parameters.AddWithValue("@Account_Number", "1234567890");
                        command.Parameters.AddWithValue("@Available_Balance", 1000);
                        command.ExecuteNonQuery();

                        // Insert into Credit_History
                        command.CommandText = insertCreditHistory;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id", 1);
                        command.Parameters.AddWithValue("@accountnumber", "1234567890");
                        command.Parameters.AddWithValue("@Balance_Credit", 500);
                        command.Parameters.AddWithValue("@creation_Time", DateTime.Now);
                        command.ExecuteNonQuery();

                        // Insert into Debit_History
                        command.CommandText = insertDebitHistory;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id", 1);
                        command.Parameters.AddWithValue("@accountnumber", "1234567890");
                        command.Parameters.AddWithValue("@Balance_Debit", 200);
                        command.Parameters.AddWithValue("@creation_Time", DateTime.Now);
                        command.ExecuteNonQuery();

                        // Commit the transaction
                        transaction.Commit();
                        Console.WriteLine("Transaction committed successfully.");
                    }
                    catch (Exception ex)
                    {
                        // Attempt to roll back the transaction
                        try
                        {
                            transaction.Rollback();
                            Console.WriteLine("Transaction rolled back due to an error: " + ex.Message);
                        }
                        catch (Exception rollbackEx)
                        {
                            Console.WriteLine("Rollback failed: " + rollbackEx.Message);
                        }
                    }
                }

            }
        }
    }
}
