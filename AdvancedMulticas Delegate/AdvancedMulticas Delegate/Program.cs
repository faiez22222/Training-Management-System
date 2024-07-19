using System;

public delegate void BankOperation(decimal amount);

public class BankAccount
{
    private decimal _balance;

    public void Deposit(decimal amount)
    {
        _balance += amount;
        Console.WriteLine($"Deposited: {amount}, New Balance: {_balance}");
    }

    public void Withdraw(decimal amount)
    {
        if (_balance >= amount)
        {
            _balance -= amount;
            Console.WriteLine($"Withdrew: {amount}, New Balance: {_balance}");
        }
        else
        {
            Console.WriteLine($"Withdrawal of {amount} failed. Insufficient funds.");
        }
    }

    public void PrintBalance(decimal amount)
    {
        Console.WriteLine($"Current Balance: {_balance}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();
        BankOperation operations = account.Deposit;
        operations += account.Withdraw;
        operations += account.PrintBalance;

        operations(100); // Perform all operations with the amount 100
    }
}
