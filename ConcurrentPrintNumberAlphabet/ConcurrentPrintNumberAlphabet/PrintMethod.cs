using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentPrintNumberAlphabet
{
    internal class PrintMethod
    {
        public void PrintNumber()
        {
            Console.WriteLine("\n");

            for (int i=1; i<=10; i++)
            {
                Console.Write(i+" ");
                Console.WriteLine("\n");
                Console.WriteLine("wait one sec");
                Thread.Sleep(1000);
            }
        }

        public void PrintAlphabet()
        {
            Console.WriteLine("\n");

            for (char c = 'a'; c<='j'; c++)
            {
                Console.Write(c + " ");
                Console.WriteLine("\n");
                Console.WriteLine("wait one and half sec");
                Thread.Sleep(1500);
            }
        }
    }
}
