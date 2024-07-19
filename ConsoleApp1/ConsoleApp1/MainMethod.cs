using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MainMethod
    {
        public static void Main()
        {
            Produce_ConsumeMethos produce_ConsumeMethos = new Produce_ConsumeMethos();
            ManualResetEvent manualResetEvent = new ManualResetEvent(false);    
            Thread thread1 = new Thread(() =>
            {
                 manualResetEvent.Set();
                 produce_ConsumeMethos.Produce();
            });

            Thread thread2 = new Thread(() =>
            {
                manualResetEvent.WaitOne();
                produce_ConsumeMethos.Consume();
            });
            thread1.Start();    
            thread2.Start();
            thread1.Join(); 
            thread2.Join(); 

        }
    }
}
