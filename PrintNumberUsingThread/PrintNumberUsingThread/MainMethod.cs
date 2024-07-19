using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNumberUsingThread
{
    internal class MainMethod
    {
        public static void  Main()
        {
            PrintMethod printMethod = new PrintMethod();
            ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            Thread thread1 = new Thread(() =>
            {
                printMethod.PrintEven();
                manualResetEvent.Set(); // Signal that the first thread has finished
            });
            Thread thread2 = new Thread(() =>
            {
                manualResetEvent.WaitOne(); // Wait for the signal from the first thread
                printMethod.PrintOdd();
            }); 
            thread1.Name = "even thread";
            thread2.Name = "odd thread";
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join(); 
        }


       


    }
}
