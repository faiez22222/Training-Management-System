using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Produce_ConsumeMethos
    {
        private static Queue<int> ints = new Queue<int>();
        private static int Buffer = 10;
        private static object lockobject = new object();    
        
        public void Produce()
        {
            for(int i=0;i<Buffer; i++)
            {
                lock (lockobject)
                {
                    while (ints.Count >= Buffer)
                    {
                        Monitor.Wait(lockobject);
                    }
                    ints.Enqueue(i);
                    Console.WriteLine($"Produced {i}");
                    Monitor.Pulse(lockobject);
                    Thread.Sleep(1000);
                }
            }
        }

        public void Consume()
        {
            for(int i=0;i<Buffer;i++)
            {
                lock (lockobject)
                {
                    while (ints.Count == 0)
                    {
                        Monitor.Wait(lockobject);
                    }
                    int item = ints.Dequeue();
                    Console.WriteLine($"Consumed {item}");
                    Monitor.Pulse(lockobject);
                    Thread.Sleep(1500);
                }
            }
            

        }
    }
}
