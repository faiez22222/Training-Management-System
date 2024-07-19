using System;
public delegate int Operation(int x, int y);

class Program
{
    public static void Main()
    {
        Operation addOperation = Add;
        Operation multiplication = Multiply;

        int result1 = addOperation(4 , 5);
        int result2 = multiplication(4 , 5);    

        Console.WriteLine($"Addresult : {result1}\nMultiplication result : {result2}");
        
    }
    static int Add(int x , int y)
    {
        return x + y;   
    }
    static int Multiply(int x , int y)
    {
        return x * y;   
    }
}