using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentPrintNumberAlphabet
{
    internal class MainMethod
    {
        public static void Main()
        {
            PrintMethod printmethod = new PrintMethod();
            Thread thread1 = new Thread(() =>
            {
                printmethod.PrintNumber();
            });
            thread1.Name = "thred1";
            Thread thread2 = new Thread(() =>
            {
                printmethod.PrintAlphabet();  
            });
            thread2.Name = "thred2";
            thread1.Start();    
            thread2.Start();    
            thread1.Join(); 
            thread2.Join();
            Console.WriteLine("Main Methos Complated");


        }

    }
}
