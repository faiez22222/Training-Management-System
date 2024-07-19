using System;

class Program
{
    static void Main(string[] args)
    {
        int a = 5;
        int b = 10; 

        Console.WriteLine($"Before swapping: a = {a}, b = {b}");

        a ^= b;
        b ^= a;
        a ^= b;

        Console.WriteLine($"After swapping: a = {a}, b = {b}");
    }
}
