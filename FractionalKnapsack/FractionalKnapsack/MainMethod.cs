using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionalKnapsack
{
    internal class MainMethod
    {
        public static void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            KnapSack[] knapSack = new KnapSack[n];
            for(int i=0; i< n; i++)
            {
                knapSack[i] = new KnapSack();
                Console.WriteLine("Enter Profir: ");
                knapSack[i].Profit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Weight: ");
                knapSack[i].Weight = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("enter capacity");
            int W = Convert.ToInt32(Console.ReadLine());
            KnapSack knapSack1 = new KnapSack();
            knapSack1.getMaximumProfit(knapSack , W);
        }


    }
}
