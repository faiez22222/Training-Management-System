using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturningDatafromAsyncMethod
{
    internal class FethDataMethod
    {
        public static async Task<string> GetDataSync()
        {
            Console.WriteLine("fetch data");
            await Task.Delay(5000);
            return "faiez";
        }
        public static async Task Main()
        {
            Console.WriteLine("Method started");
            string s =await GetDataSync();
            Console.WriteLine(s);
            Console.WriteLine("main method ended");
        }
    }
}
