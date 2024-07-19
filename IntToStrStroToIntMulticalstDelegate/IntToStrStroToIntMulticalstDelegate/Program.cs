using System;
using System.Collections.Generic;

public delegate void ConverterDelegate(object obj);

public class Converter
{
    public void ConvertIntToString(object obj)
    {
        if (obj is int x)
        {
            Console.WriteLine("Converted to string: " + x.ToString());
        }
        else
        {
            Console.WriteLine("Invalid input for ConvertIntToString");
        }
    }

    public void ConvertStringToInt(object obj)
    {
        if (obj is string x)
        {
            int y;
            if (int.TryParse(x, out y))
            {
                Console.WriteLine("Converted to integer: " + y);
            }
            else
            {
                Console.WriteLine("Conversion failed for string: " + x);
            }
        }
        else
        {
            Console.WriteLine("Invalid input for ConvertStringToInt");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Converter converter = new Converter();

        ConverterDelegate converterDelegate = new ConverterDelegate(converter.ConvertIntToString);
        converterDelegate += new ConverterDelegate(converter.ConvertStringToInt);

        List<object> items = new List<object> { 1, 2, 3, 4, 5, "1", "2", "3", "4", "5" };

        foreach (object item in items)
        {
            converterDelegate.Invoke(item);
        }
    }
}
