using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleAsyncOperations
{
    internal class MainMethod
    {
        public static async Task ProcessMultipleTasksAsync()
        {
            Task task1 = Task.Delay(1000);
            Task task2 = Task.Delay(3000);

            Task task3 = Task.Delay(6000);
            Console.WriteLine("methos started");
            await Task.WhenAll(task1, task2, task3);
            Console.WriteLine("methos ended");



        }
        public static async Task Main()
        {
            Console.WriteLine("Main methos started");
            await  ProcessMultipleTasksAsync();
            Console.WriteLine("main method started");

        }
    }
}
