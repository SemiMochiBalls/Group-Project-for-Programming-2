using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Group_Project_for_Programming_2
{

    public abstract class Account
    {
        protected readonly List<Person> users;
        protected readonly List<Transaction> transactions;
        private static int LAST_NUMBER = 100000;

        public double Balance { get; protected set; }
        public double LowestBalance { get; protected set; }
        public string Number { get; }

        public event EventHandler OnTransaction;

        public Account(string type, double balance)
        {
            Number = type + LAST_NUMBER++;
            Balance = balance;
            LowestBalance = balance;
            transactions = new List<Transaction>();
            users = new List<Person>();
        }

        public void Deposit(double amount, Person person)
        {
            Balance += amount;
            if (Balance < LowestBalance)
            {
                LowestBalance = Balance;
            }

            var transaction = new Transaction(Number, amount, person);
            transactions.Add(transaction);
            OnTransaction?.Invoke(this, EventArgs.Empty);
        }

        public void AddUser(Person person)
        {
            users.Add(person);
        }

        public bool IsUser(string name)
        {
            return users.Any(p => p.Name == name);
        }

        public abstract void PrepareMonthlyReport();

        public virtual void OnTransactionOccur(object sender, EventArgs args)
        {
            OnTransaction?.Invoke(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            var result = $"{Number} - Users: ";
            result += string.Join(", ", users.Select(p => p.Name));
            result += $", Balance: {Balance:C2}";
            result += "\nTransactions:\n";
            foreach (var transaction in transactions)
            {
                result += transaction + "\n";
            }
            return result;
        }
    }
}
