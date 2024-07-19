using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock_Scenario_in_C__and_Its_Resolution
{
    internal class DemonstrateDeadlock
    {
        private static readonly object lock1 = new object();
        private static readonly object lock2 = new object();

        public static void Main()
        {
            Thread thread1 = new Thread(thread1Method);
            Thread thread2 = new Thread(thread2Method);
            thread1.Name = "thread1";
            thread2.Name = "thread2";
            thread1.Start();    
            thread2.Start();    

            thread1.Join(); 
            thread2.Join();
            Console.WriteLine("MainMethod Completed");
        }

        static void thread1Method()
        {
            lock (lock1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock1");
                Thread.Sleep(1000);
                lock (lock2) {
                    Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock2");
                }
            }

            
        }
        static void thread2Method()
        {
            lock (lock1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock1");
                Thread.Sleep(1000);
                lock (lock2)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock2");
                }
            }
        }
    }
}
