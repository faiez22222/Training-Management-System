using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class Manager: Employee
    {
        public Manager()
        {

        }
        public Manager(string name , string title):base(name, title)
        {

        }
        public Manager(string name , string title, string gender, int age, decimal baseSalary):base(name , title , gender , age , baseSalary)
        {

        }

        public decimal CalculateBonus()
        {
            return BaseSalary * 0.10m;
        }
        public new void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Bonus: {CalculateBonus():C}");
        }
    }
}
