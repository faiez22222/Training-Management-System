using System;

public delegate int Calculate(int x, int y);

class Program
{
    static void Main(string[] args)
    {
        Calculate add = delegate (int x, int y)
        {
            return x + y;
        };

        Calculate subtract = delegate (int x, int y)
        {
            return x - y;
        };

        Console.WriteLine($"Addition: {add(10, 5)}");
        Console.WriteLine($"Subtraction: {subtract(10, 5)}");
    }
}
