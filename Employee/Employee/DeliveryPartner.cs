using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class DeliveryPartner : Employee
    {
        public DeliveryPartner() { }
        public DeliveryPartner(string name, string title)
            : base(name, title) { }

        public DeliveryPartner(string name, string title, string gender, int age, decimal baseSalary)
            : base(name, title, gender, age, baseSalary) { }
        public decimal CalculateBonus()
        {
            return BaseSalary * 0.20m;
        }

        public new void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Bonus: {CalculateBonus():C}");
        }
    }

}
