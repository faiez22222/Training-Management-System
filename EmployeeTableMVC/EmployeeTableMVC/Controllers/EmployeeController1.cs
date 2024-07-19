using EmployeeTableMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace EmployeeTableMVC.Controllers
{
    public class EmployeeController1 : Controller
    {
        private List<Employee> _employees;
        string connectionString = @"data source=DESKTOP-TIC5DM4\SQLEXPRESS;Database=NewDB;Integrated Security=SSPI;";
        public List<Employee> Employees
        {
            get
            {
                if (_employees == null)
                {
                    _employees = FetchEmployeesFromDatabase();
                }
                return _employees;
            }
        }

        private List<Employee> FetchEmployeesFromDatabase()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, FirstName, LastName, DateOfBirth, Email, Age, Country, Gender FROM Employees";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                DateOfBirth = reader.GetDateTime(3),
                                Email = reader.GetString(4),
                                Age = reader.GetString(5),
                                Country = reader.GetString(6),
                                gender = reader.GetString(7)
                            };
                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }

        // This method adds a single employee to the list
        public void AddEmployee(Employee employee)
        {
            string insertIntoEmployees = @"
                INSERT INTO Employees (FirstName, LastName, DateOfBirth, Email, Age, Country, Gender)
                VALUES (@FirstName, @LastName, @DateOfBirth, @Email, @Age, @Country, @Gender);";

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
                        command.CommandText = insertIntoEmployees;
                        command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        command.Parameters.AddWithValue("@LastName", employee.LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                        command.Parameters.AddWithValue("@Email", employee.Email);
                        command.Parameters.AddWithValue("@Age", employee.Age);
                        command.Parameters.AddWithValue("@Country", employee.Country);
                        command.Parameters.AddWithValue("@Gender", employee.gender);
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        Console.WriteLine("Transaction committed successfully.");
                    }
                    catch (Exception ex)
                    {
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

        public ActionResult Index()
        {
            return View(Employees);
        }

        // GET: EmployeeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                AddEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
