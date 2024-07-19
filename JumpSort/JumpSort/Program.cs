using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the number of elements in the array:");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        Console.WriteLine("Enter the elements of the array (separated by space):");
        string[] input = Console.ReadLine().Split(' ');

        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(input[i]);
        }
        Array.Sort(arr);

        Console.WriteLine("Enter the element to search:");
        int target = int.Parse(Console.ReadLine());

        int index = JumpSearch(arr, target);

        if (index != -1)
        {
            Console.WriteLine($"Element {target} found at index {index}.");
        }
        else
        {
            Console.WriteLine($"Element {target} not found in the array.");
        }
    }

    public static int JumpSearch(int[] arr, int target)
    {
        int n = arr.Length;
        int step = (int)Math.Floor(Math.Sqrt(n));

        int prev = 0;
        while (arr[Math.Min(step, n) - 1] < target)
        {
            prev = step;
            step += (int)Math.Floor(Math.Sqrt(n));
            if (prev >= n)
                return -1;
        }

        while (arr[prev] < target)
        {
            prev++;
            if (prev == Math.Min(step, n))
                return -1;
        }

        if (arr[prev] == target)
            return prev;

        return -1;
    }
}
