using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class WriteFileConcurrently
    {
        private static readonly object lockObj = new object();
        public static void CustomAppendAllText(string path, string contents)
        {
            lock (lockObj)
            {
                File.AppendAllText(path, contents + Environment.NewLine);
            }
        }
        public static async Task WriteNumbersInAsync(string filePath, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                CustomAppendAllText(filePath, i.ToString());
                await Task.Delay(10); 
            }
        }

        public static void WriteNumbersInSync(string filePath, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                CustomAppendAllText(filePath, i.ToString());
                Thread.Sleep(200); // 200 ms delay
            }
        }

        public static async Task WriteNumbersInParallel()
        {
            string file1 = "C:\\WriteFiles\\Log1.txt";
            string file2 = "C:\\WriteFiles\\Log2.txt";
            string file3 = "C:\\WriteFiles\\Log3.txt";

            Task task1 = WriteNumbersInAsync(file1, 1, 100);
            Task task2 = WriteNumbersInAsync(file2, 1, 100);
            Task task3 = WriteNumbersInAsync(file3, 1, 100);

            await Task.WhenAll(task1, task2, task3);
        }

        // Method to read all lines from a file asynchronously
        public static async Task<string[]> ReadAllLinesAsync(string filePath)
        {
            return await Task.Run(() => File.ReadAllLines(filePath));
        }

        // Method to read data from files in parallel
        public static async Task ReadFilesInParallelAsync()
        {
            string file1 = "C:\\WriteFiles\\Log1.txt";
            string file2 = "C:\\WriteFiles\\Log2.txt";
            string file3 = "C:\\WriteFiles\\Log3.txt";

            Task<string[]> task1 = ReadAllLinesAsync(file1);
            Task<string[]> task2 = ReadAllLinesAsync(file2);
            Task<string[]> task3 = ReadAllLinesAsync(file3);

            await Task.WhenAll(task1, task2, task3);

            string[] lines1 = await task1;
            string[] lines2 = await task2;
            string[] lines3 = await task3;

            Console.WriteLine($"Contents of {file1}:");
            foreach (var line in lines1)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine($"\nContents of {file2}:");
            foreach (var line in lines2)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine($"\nContents of {file3}:");
            foreach (var line in lines3)
            {
                Console.WriteLine(line);
            }
        }

        public static async Task Main()
        {
            await WriteNumbersInParallel();
            Console.WriteLine("Finished writing numbers to files in parallel.");

            string file4 = "C:\\WriteFiles\\Log4.txt";
            WriteNumbersInSync(file4, 1, 10);
            Console.WriteLine("Finished writing numbers to file synchronously with delay.");

            await ReadFilesInParallelAsync();
            Console.WriteLine("Finished reading data from files in parallel.");
        }
    }
}
