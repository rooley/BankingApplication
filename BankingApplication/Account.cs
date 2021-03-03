using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    // Abstract class that all other account types inherit from
    public abstract class Account
    {
        public string owner;
        public double balance;
        public abstract bool Withdraw(double amount);
        public abstract void Deposit(double amount);
        public abstract bool Transfer(Account account, double amount);
    }
}
