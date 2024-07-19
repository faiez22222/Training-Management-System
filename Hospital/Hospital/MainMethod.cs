using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class MainMethod
    {
        public enum Department
        {
            General = 400 ,
            ENT =  800 ,
            Cardiology =1200 ,
            OperationTheator = 5000 ,
            IntensiveCareUnit = 6000 

        }
        public static void Main()
        {
            Console.WriteLine("Welcome to ABC hospital");
            Console.WriteLine("Select the department for the treatment"); 
            Console.WriteLine("1.General  : 400");
            Console.WriteLine("2.ENT  : 800");
            Console.WriteLine("3.Cardiology  : 1200");
            Console.WriteLine("4.OperationTheator  : 5000");
            Console.WriteLine("5.IntensiveCareUnit  : 6000");
            string selectedDepartment;
            int x = Convert.ToInt32(Console.ReadLine());
            switch(x)
            {
                case 400:
                    {
                        selectedDepartment = nameof(Department.General); break; 
                    }
                case 800:
                    {
                        selectedDepartment = nameof(Department.ENT); break;
                    }
                case 1200:
                    {
                        selectedDepartment = nameof(Department.Cardiology); break;
                    }
                case 5000:
                    {
                        selectedDepartment = nameof(Department.OperationTheator); break;
                    }
                case 6000:
                    {
                        selectedDepartment = nameof(Department.IntensiveCareUnit); break;
                    }
                default:
                        Console.WriteLine("Invalid Option");
                        break;

            }

            Console.WriteLine("Enter petient detail");
            Petient[] petients = new Petient[3];
            for(int i = 0;i < 3; i++)
            {
                Console.WriteLine($"Enter {i + 1}th petient detail");
                Console.WriteLine("Enter first name");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter last name");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter gender");
                string gender = Console.ReadLine();
                Console.WriteLine("Enter age");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter phone number");
                string number = Console.ReadLine() ;
                Console.WriteLine("Enter state");
                string state = Console.ReadLine() ;
                Console.WriteLine("Enter pincode");
                string pincode = Console.ReadLine() ;

                petients[i] = new Petient();
                petients[i].FirstName = firstName;
                petients[i].LastName = lastName;
                petients[i].Gender = gender;
                petients[i].Age = age;
                petients[i].Number = number;
                petients[i].State = state;
                petients[i].Pincode = pincode;

                Console.WriteLine("\n");
            }
            Console.WriteLine("Search the petient detail through contact number");
            Console.WriteLine("Enter phone number");
            string contactInfo = Console.ReadLine();    
            for(int i=0; i< 3; i++)
            {
                if (petients[i].Number == contactInfo)
                {
                    Console.WriteLine($"First Name: {petients[i].FirstName}");
                    Console.WriteLine($"Last Name: {petients[i].LastName}");
                    Console.WriteLine($"Gender: {petients[i].Gender}");

                    Console.WriteLine($"Age: {petients[i].Age}");

                    Console.WriteLine($"Contact Information: {petients[i].Number}");
                    Console.WriteLine($"State: {petients[i].State}");
                    Console.WriteLine($"Pincode: {petients[i].Pincode}");`

                }
            }

        }
    }
}
