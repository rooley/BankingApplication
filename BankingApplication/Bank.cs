using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class Bank
    {
        // All banks have a name and a list of accounts
        public string name;
        public List<Account> accounts;
        
        public Bank(string name)
        {
            this.name = name;
            accounts = new List<Account>();
        }

        // Adds a new account to a bank, does not accept null values for account
        public void AddToBank(Account account)
        {
            if (account != null)
            {
                accounts.Add(account);
            }
        }
    }
}
