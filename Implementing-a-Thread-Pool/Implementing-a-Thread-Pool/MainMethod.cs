using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementing_a_Thread_Pool
{
    internal class MainMethod
    {
        private static readonly Random random = new Random();
        private static readonly object lockobject = new object();
        private static int taskrenaming = 10;

        public static void Main()
        {
            for(int i=0; i<10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessTask) , i);
            }
            lock(lockobject)
            {
                while(taskrenaming > 0)
                {
                    Monitor.Wait(lockobject);
                }
            }
            Console.WriteLine("All tasks have been completed.");
        }

        static void ProcessTask(object TaskId )
        {
            int id = (int)TaskId;
            Console.WriteLine($"task {id} started");
            int sleeptime = random.Next( 1000  , 5000);

            Thread.Sleep(sleeptime);
            Console.WriteLine($"Task {id} completed after {sleeptime / 1000} seconds");

            lock(lockobject)
            {
                taskrenaming--;
                if(taskrenaming==0)
                {
                    Monitor.Pulse(lockobject);
                }
            }
        }
    }
}
