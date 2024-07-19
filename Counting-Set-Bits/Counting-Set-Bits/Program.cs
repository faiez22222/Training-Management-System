using System;

class CountSetBitsProgram
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(CountSetBits(n));
    }

    static string CountSetBits(int n)
    {
        string result = "";
        for (int i = 1; i <= n; i++)
        {
            int setBits = CountBits(i);
            result += $"{i}:Number of set bit count : {setBits}\n";
        }
        return result;
    }

    static int CountBits(int x)
    {
        int count = 0;
        while (x != 0)
        {
            count += x & 1;
            x >>= 1;
        }
        return count;
    }
}
