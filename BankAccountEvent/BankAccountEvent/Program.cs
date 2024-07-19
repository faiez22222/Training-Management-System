using System;

public class AccountBalanceBeforeTransactionEventArgs : EventArgs
{
    public decimal OldPrice { get; }


    public AccountBalanceBeforeTransactionEventArgs(decimal oldPrice)
    {
        OldPrice = oldPrice;
    }
}

public class AccountBalanceAfterTransactionEventArgs : EventArgs
{
    public decimal OldPrice { get; }
    public decimal NewPrice { get; }


    public AccountBalanceAfterTransactionEventArgs(decimal oldPrice , decimal newPrice)
    {
        OldPrice = oldPrice;
        NewPrice = newPrice;    
    }
}


public class Account
{
    private string _accountType;
    private decimal _accountBalance;

    public Account(string accountTpe, decimal accountBalance)
    {
       _accountBalance = accountBalance;    
        _accountType = accountTpe;  
    }

    public event EventHandler<AccountBalanceBeforeTransactionEventArgs> BeforeAccountBalanceChanged;
    public event EventHandler<AccountBalanceAfterTransactionEventArgs> AfterAccountBalanceChanged;

    public void Deposit(decimal value)
    {
        decimal oldBalance = _accountBalance;
        onChangeBeforeTransaction(new AccountBalanceBeforeTransactionEventArgs(oldBalance));
        Thread.Sleep(1000);

        _accountBalance += value;
        onChangeAfterTransaction(new AccountBalanceAfterTransactionEventArgs(oldBalance , _accountBalance));

    }

    protected virtual void onChangeBeforeTransaction(AccountBalanceBeforeTransactionEventArgs e)
    {
        BeforeAccountBalanceChanged?.Invoke(this, e);
    }
    protected virtual void onChangeAfterTransaction(AccountBalanceAfterTransactionEventArgs e)
    {
        AfterAccountBalanceChanged?.Invoke(this, e);
    }


}

public class Subscriber
{
    public void onChangeBeforeTransaction(object sender , AccountBalanceBeforeTransactionEventArgs e)
    {
        Console.WriteLine($"Account Balance before transaction is {e.OldPrice}");
    }
    public void onChangeAfterTransaction(object sender, AccountBalanceAfterTransactionEventArgs e)
    {
        Console.WriteLine($"Account Balance after transaction is {e.NewPrice}");
    }
}



class Program
{
    static void Main(string[] args)
    {
        Account account = new Account("saving type", 500000);
        Subscriber subscriber = new Subscriber();
        account.BeforeAccountBalanceChanged +=subscriber.onChangeBeforeTransaction;
        account.AfterAccountBalanceChanged += subscriber.onChangeAfterTransaction;
        account.Deposit(1000);
    }
}
