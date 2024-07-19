using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCar
{
    internal class MainMethod
    {
        public static void Main()
        {
            Car car1 = new Car("Toyota", "Corolla");
            Car car2 = new Car("Honda", "Civic");

            Bycycle bicycle1 = new Bycycle("Trek", "Mountain");
            Bycycle bicycle2 = new Bycycle("Giant", "Road");

            IDrivable[] dricable = new IDrivable[] { car1 , car2 , bicycle1 ,bicycle2};
            foreach (IDrivable d in dricable )
            {
                d.Stop();   
                d.Start();  
                d.Drive();
            }
        }
    }
}
