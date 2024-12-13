using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankConsoleApp
{
    public class Account
    {
        private static int accountCounter = 1000;

        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public List<Transaction> Transactions { get; private set; }

        public Account()
        {
            AccountNumber = (accountCounter++).ToString();
            Balance = 0;
            Transactions = new List<Transaction>();
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new InvalidOperationException("Сумата трябва да бъде положителна.");

            Balance += amount;
            Transactions.Add(new Transaction("Депозит", amount));
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new InvalidOperationException("Сумата трябва да бъде положителна.");
            if (amount > Balance) throw new InvalidOperationException("Недостатъчно средства.");

            Balance -= amount;
            Transactions.Add(new Transaction("Теглене", amount));
        }
    }
}
