﻿namespace EmployeeTableMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Country { get; set; }

        public string gender { get; set; }
    }
}
