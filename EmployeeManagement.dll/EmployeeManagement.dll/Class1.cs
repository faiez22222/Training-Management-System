using System;

namespace EmployeeManagement
{
    public class Employee
    {
        public int _id;
        public string _name;
        private string _position;
        private decimal _salary;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id must be positive.");
                }
                _id = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                _name = value;
            }
        }

        public string Position
        {
            get { return _position; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Position cannot be empty.");
                }
                _position = value;
            }
        }

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative.");
                }
                _salary = value;
            }
        }

        public Employee(int id, string name, string position, decimal salary)
        {
            Id = id;
            Name = name;
            Position = position;
            Salary = salary;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Salary: {Salary:C}");
        }

        public decimal CalculateBonus(decimal percentage)
        {
            if (percentage < 0)
            {
                throw new ArgumentException("Percentage cannot be negative.");
            }
            return Salary * (percentage / 100);
        }

        public void PrintPIValue(int number, string text)
        {
            Console.WriteLine($"Number: {number}, Text: {text}");
        }
    }
}
