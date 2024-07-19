using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class MainMethod
    {
        public static void main()
        {
            Account employee1 = new Account(123 , 50000);
            Account employee2 = new Account(124, 60000);
            Account employee3 = new Account(125, 70000);

            AccountManager accountManager = new AccountManager(employee1, employee2 ,2000);
            AccountManager accountManager2 = new AccountManager(employee2, employee1, 5000);
            Thread thread = new Thread(new ThreadStart(accountManager.transfer));
            Thread thread2 = new Thread(new ThreadStart(accountManager2.transfer));
            thread.Start();
            thread2.Start();
            thread.Join();
            thread2.Join(); 
            Console.WriteLine("main thread complete");
        }
    }
}
