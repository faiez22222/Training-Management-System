using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCar
{
    internal class Bycycle:IDrivable
    {

        public string Brand { get; set; }
        public string Type { get; set; }

        public Bycycle(string brand, string type)
        {
            Brand = brand;
            Type = type;
        }

        public void Start()
        {
            Console.WriteLine($"{Brand} {Type}  is started");
        }
        public void Stop()
        {
            Console.WriteLine($"{Brand} {Type} is stop");
        }
        
        public void Drive()
        {
            Console.WriteLine($"{Brand} {Type} is running");
        }
    }
}
