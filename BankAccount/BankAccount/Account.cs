using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class Account
    {
       public int accountId;
       public decimal accountBalance;
       public Account(int accountId, decimal accountBalance )
        {
            this.accountId = accountId;
            this.accountBalance = accountBalance;
        }
    }
}
