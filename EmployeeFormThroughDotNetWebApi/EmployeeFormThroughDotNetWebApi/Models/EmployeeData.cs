using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeFormThroughDotNetWebApi.Models
{
    public class EmployeeData
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Gender {  get; set; } 
        public string Address { get; set; } 

    }
}
