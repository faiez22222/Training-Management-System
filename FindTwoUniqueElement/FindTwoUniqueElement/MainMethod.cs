using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTwoUniqueElement
{
    internal class MainMethod
    {
        public static void main()
        {
            Console.WriteLine("Enter the size of array");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine("enter array with only two unique element");
            for(int i=0; i< n;i ++)
            {
                int x = Convert.ToInt32(Console.ReadLine()); ;
                arr[i] = x;
            }

            int xor = 0;
            for(int i=0; i<n;i++)
            {
                xor = xor^ arr[i];  
            }
            int rightsetbit = xor & -xor;
            int num1 = 0;
            int num2 = 0;
            for(int i=0;i<n;i++)
            {
                if ((arr[i]&xor) == 1 )
                {
                    num1 = num1 ^ arr[i];
                }
                else
                {
                    num2 = num2 ^ arr[i];
                }
            }
            Console.WriteLine($"number 1 : {num1} , number 2 : {num2}");
        }
    }
}
