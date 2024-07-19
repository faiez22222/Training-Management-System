using CustomStack;
using System;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose the type of stack:");
            Console.WriteLine("1. Integer");
            Console.WriteLine("2. Double");
            Console.WriteLine("3. Char");
            Console.WriteLine("4. Boolean");
            Console.WriteLine("5. Exit");
            string typeChoice = Console.ReadLine();

            switch (typeChoice)
            {
                case "1":
                    HandleStack<int>();
                    break;
                case "2":
                    HandleStack<double>();
                    break;
                case "3":
                    HandleStack<char>();
                    break;
                case "4":
                    HandleStack<bool>();
                    break;
                case "5":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public static void HandleStack<T>()
    {
        IStack<T> stack = new SimpleStack<T>()    ;

        while (true)
        {
            Console.WriteLine($"Current stack type: {typeof(T).Name}");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Push an element");
            Console.WriteLine("2. Pop an element");
            Console.WriteLine("3. Peek at the top element");
            Console.WriteLine("4. Check if stack is empty");
            Console.WriteLine("5. Get the count of elements");
            Console.WriteLine("6. Go back to type selection");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write($"Enter a {typeof(T).Name} to push onto the stack: ");
                    try
                    {
                        T item = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                        stack.Push(item);
                        Console.WriteLine($"{item} pushed onto the stack.");
                    }
                    catch
                    {
                        Console.WriteLine($"Invalid input. Please enter a valid {typeof(T).Name}.");
                    }
                    break;

                case "2":
                    try
                    {
                        T poppedItem = stack.Pop();
                        Console.WriteLine($"{poppedItem} popped from the stack.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "3":
                    try
                    {
                        T topItem = stack.Peek();
                        Console.WriteLine($"{topItem} is at the top of the stack.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "4":
                    Console.WriteLine(stack.IsEmpty ? "The stack is empty." : "The stack is not empty.");
                    break;

                case "5":
                    Console.WriteLine($"The stack contains {stack.Count} elements.");
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
