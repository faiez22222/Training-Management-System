using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionalKnapsack
{
    public class SortItem : IComparer<KnapSack>
    {
        public int Compare(KnapSack x , KnapSack y)
        {
            double ratio1 = x.Profit / x.Weight;
            double ration2 = y.Profit / y.Weight;
            return ration2.CompareTo(ratio1);
        }
    }
    public class KnapSack
    {

        public int Profit { get; set; } 
        public int Weight { get; set; }

        public KnapSack()
        {

        }
        public KnapSack(int profit, int weight )
        {
            this.Profit = profit;
            this.Weight = weight;
        }
        public void getMaximumProfit(KnapSack[] knapSacks , int capacity)
        {
           int n = knapSacks.Length;
           Array.Sort(knapSacks , new SortItem());
            double finalValue = 0.0;
            for(int i=0;i< n;i++)
            {
                if (knapSacks[i].Weight<=capacity)
                {
                    finalValue += knapSacks[i].Profit;
                    capacity -= knapSacks[i].Weight;
                }
                else
                {
                    double fraction = capacity / knapSacks[i].Weight;
                    finalValue += knapSacks[i].Profit * fraction;
                    break;
                }
            }
            Console.WriteLine("finalvalue: " + finalValue);
          
          
        }
    }
}
