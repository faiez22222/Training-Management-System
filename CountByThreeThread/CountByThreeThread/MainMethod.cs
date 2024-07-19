using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountByThreeThread
{
    internal class MainMethod
    {
        public static void Main()
        {
            CounterMethod counterMethod = new CounterMethod();

            Thread thread1 = new Thread(counterMethod.PrintCounter);
            Thread thread2 = new Thread(counterMethod.PrintCounter);
            Thread thread3 = new Thread(counterMethod.PrintCounter);

            thread1.Name = "thread1";
            thread2.Name = "thread2";
            thread3.Name = "thread3";

            thread1.Start();
            thread2.Start();
            thread3.Start();    

            thread1.Join(); 
            thread2.Join(); 
            thread3.Join(); 

        }
    }
}
