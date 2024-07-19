using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class MainClass
    {
        public static void Main()
        {
            Employee employee = new Employee("faiez" , "developer" , "male" , 21 , 50000);
            employee.DisplayDetails();
            Console.WriteLine("\n");

            Manager employee2 = new Manager("naveen", "manager", "male", 22, 100000);
            employee2.DisplayDetails();
            Console.WriteLine("\n");

            DeliveryPartner employee3 = new DeliveryPartner("Subiya", "Delivery Partner", "male", 22, 1000000);
            employee3.DisplayDetails(); 
        }
    }
}
