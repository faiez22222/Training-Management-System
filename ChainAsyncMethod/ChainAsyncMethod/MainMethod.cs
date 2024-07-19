using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainAsyncMethod
{
    internal class MainMethod
    {
        public static async Task<string> FirstOperationAsync()
        {
            Console.WriteLine("FirstOperationAsync started");
            await Task.Delay(2000);
            return "faiez";
        }
        public static async Task SecondOperationAsync(string s)
        {
            Console.WriteLine("SecondOperationAsync started");
            await Task.Delay(2000);
            Console.WriteLine(s);
            Console.WriteLine("SecondOperationAsync ended");
        }
        public static async Task Main()
        {
            Console.WriteLine("main method started");
            string s =await FirstOperationAsync();
            await SecondOperationAsync(s);
            Console.WriteLine("main Method ended");
        }
    }
}
