using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSequencingProblem
{
    internal class MainMethod
    {
        public static void Main()
        {
            Console.WriteLine("enter size of array");
            int n = Convert.ToInt32(Console.ReadLine());
            Item[] item = new Item[n];
            Item item1 = new Item();
            Console.WriteLine("Enter id , profit and deadline");
            for(int i= 0;i< n;i++)
            {
                item[i] = new Item();
                Console.Write("enter id: ");
                item[i].Id =  Convert.ToChar(Console.ReadLine());   
                Console.Write("Enter profit: ");
                item[i].Profit = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter deadline: ");
                item[i].Deadline = Convert.ToInt32(Console.ReadLine());
            }
            item1.getMaxProfit(item , n);
        }
    }
}
