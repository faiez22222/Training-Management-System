using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class Employee
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal BaseSalary { get; set; }

        public Employee()
        {

        }
        public Employee(string name , string title)
        {
            this.Name = name;
            this.Title = title;
        }
        public Employee(string name, string title, string gender, int age, decimal baseSalary )
        {
            this.Name = name;
            this.Title = title;
            this.Gender = gender;
            this.Age = age; 
            this.BaseSalary= baseSalary;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Base Salary: {BaseSalary:C}");
        }

    }


}
