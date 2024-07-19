using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfAppLogin
{
    public class LoginDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName {  get; set; } 

        public string LastName { get; set; }  

        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string DateOfBirth {  get; set; }     
        public string country {  get; set; }    
        public string state {  get; set; }  
        public string city {  get; set; }   
    }
}
