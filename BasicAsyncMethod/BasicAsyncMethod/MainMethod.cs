using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAsyncMethod
{
    internal class MainMethod
    {
        public static async Task DownLoadFile()
        {
            Console.WriteLine("downloaded starting");
            await Task.Delay(1000);
            Console.WriteLine("downloaded ended");
        }
        public static async Task Main()
        {
            Console.WriteLine("main methos started");
            await DownLoadFile();
            Console.WriteLine("main methos eneded");
        }
    }
}
