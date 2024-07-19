using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Petient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; } 
        public int Age { get; set; }
        public string Number { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }    

        public Petient()
        {

        }
        public Petient(string firstName , string lastName , string gender , int age , string number , string state , string pincode)
        {
            FirstName = firstName;  
            LastName = lastName;    
            Gender = gender;    
            Age = age;  
            Number = number;    
            Pincode = pincode;
        }

       




    }
}
