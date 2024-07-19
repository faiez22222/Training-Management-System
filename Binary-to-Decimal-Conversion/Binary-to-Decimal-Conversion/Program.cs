using System;

class BinaryToDecimalProgram
{
    static void Main()
    {
        Console.Write("Enter a binary string: ");
        string binaryStr = Console.ReadLine();

        int decimalValue = BinaryToDecimal(binaryStr);
        Console.WriteLine($"The decimal value of binary string {binaryStr} is {decimalValue}");
    }

    static int BinaryToDecimal(string binaryStr)
    {
        int decimalValue = 0;
        int baseValue = 1;

        for (int i = binaryStr.Length - 1; i >= 0; i--)
        {
            if (binaryStr[i] == '1')
            {
                decimalValue += baseValue;
            }
            baseValue *= 2; 
        }

        return decimalValue;
    }
}
