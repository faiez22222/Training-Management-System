using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCar
{
    internal class Car:IDrivable
    {

        public string Make { get; set; }
        public string Model { get; set; }

        public Car(string make, string model)
        {
            Make = make;
            Model = model;
        }
        public void Stop()
        {
            Console.WriteLine($"{Make} {Model} is stop");
        }

        public void Start()
        {
           Console.WriteLine($"{Make} {Model} Car started.");
        }
        public void Drive()
        {
            Console.WriteLine($"{Make} {Model} is running");
        }
    }
}
