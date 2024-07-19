using System;
public delegate void Notify();
public class Program
{
    public static void Main()
    {
        Notify notify = PrintHello;
        notify += PrintGoodBuy;
        notify.Invoke();
    }
    public static void PrintHello()
    {
        Console.WriteLine("Hello");
    }
    public static void PrintGoodBuy()
    {
        Console.WriteLine("Goodbuy");
    }
}