using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountByThreeThread
{
    internal class CounterMethod
    {
        int counter = 0;
        static object lockobject = new object(); 
        public void PrintCounter()
        {
            for (int i = 0; i <= 100; i++)
            {
                lock (lockobject)
                {
                    counter++;
                    Console.WriteLine($"{counter} incremented by {Thread.CurrentThread.Name}");
                }
            }
        }
    }
}
