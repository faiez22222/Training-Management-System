using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class AccountManager
    {
        private Account fromAcount;
        private Account toAcount;
        decimal amount;
        private readonly object balancelock = new object();
        public AccountManager(Account fromAccount , Account toAccount , decimal amount )
        {
            this.fromAcount = fromAccount;
            this.toAcount = toAccount;
            this.amount = amount;
        }

        public void transfer()
        {
            lock (balancelock)
            {
                int accountIdA = fromAcount.accountId;
                int accountIdB = toAcount.accountId;
                fromAcount.accountBalance = fromAcount.accountBalance - amount;
                toAcount.accountBalance = toAcount.accountBalance + amount;
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed.");
                Console.WriteLine($"debit {amount} from account {accountIdA} credit to account {accountIdB}");
            }
        }

    }
}
