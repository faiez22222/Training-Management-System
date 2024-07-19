using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNumberUsingThread
{
    internal class PrintMethod
    {
        public void PrintEven()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"{i} printed by {Thread.CurrentThread.Name}");
                }
            }
        }
        public void PrintOdd()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine($"{i} printed by {Thread.CurrentThread.Name}");
                }
            }
        }
    }
}
