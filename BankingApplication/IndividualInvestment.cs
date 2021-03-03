using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class IndividualInvestment : Account
    {

        public IndividualInvestment(string name)
        {
            owner = name;
            balance = 0;
        }

        // Deposits a valid (positive) amount into checking account
        public override void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }

        // Withdraws a valid amount from the account
        // a positive number less than or equal to the current account balance and less than or equal to 1000 as per the requirements
        public override bool Withdraw(double amount)
        {
            if (amount <= balance && amount <= 1000 && amount > 0)
            {
                balance -= amount;
                return true;
            }

            return false;
        }
        // Withdraws a valid amount from this account and deposits it into the account parameter
        // a positive number less than or equal to the current account balance
        public override bool Transfer(Account account, double amount)
        {
            if (account != null)
            {
                if (amount <= balance && amount > 0)
                {
                    balance -= amount;
                    account.balance += amount;
                    return true;
                }
            }

            return false;
        }
    }
}

