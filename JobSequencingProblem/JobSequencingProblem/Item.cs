using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSequencingProblem
{
    public class SortItem : IComparer<Item>
    {
        public int Compare(Item x , Item y)
        {
            if (x.Profit < y.Profit) return 1;
            else if (x.Profit > y.Profit) return -1;
            else return 0;  
        }
    }
    public class Item
    {
        public int Profit;
        public int Deadline;
        public char Id;
        public Item() { }   
        public Item(int profit, int deadline , char id)
        {
            Profit = profit;
            Deadline = deadline;
            Id = id;
        } 
        public void getMaxProfit(Item[] jobs , int n)
        {
           SortItem sortItem = new SortItem();
           Array.Sort(jobs, sortItem);
            int[] result = new int[jobs.Length];
            bool[] slot = new bool[jobs.Length];
            for(int i=0;i<n;i++)
            {
                slot[i] = false;
            }
            for(int i=0;i<n; i++)
            {
                for(int j = Math.Min(n , jobs[i].Deadline)-1; j>=0; j--)
                {
                    if (slot[j]==false)
                    {
                        result[j] = i;
                        slot[j] = true;
                        break;
                    }
                }
            }
            for(int i=0; i<n;i++)
            {
                if (slot[i]==true)
                {
                    Console.WriteLine(jobs[result[i]].Id);
                }
            }
        }
    }
}
