using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_for_Programming_2
{
    class VisaAccount : Account, ITransaction
    {
        private double creditLimit;
        private const double INTEREST_RATE = 0.1995;

        public VisaAccount(double balance = 0, double creditLimit = 1200)
            : base("VS-", balance)
        {
            this.creditLimit = creditLimit;
        }

        public void DoPayment(double amount, Person person)
        {
            Deposit(amount, person);
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, true));
        }

        public void DoPurchase(double amount, Person person)
        {
            if (!IsAssociatedWithAccount(person))
            {
                OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }

            if (!IsLoggedIn(person))
            {
                OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(ExceptionType.USER_NOT_LOGGED_IN);
            }

            if (amount > Balance + creditLimit)
            {
                OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(ExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }

            Deposit(-amount, person);
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, true));
        }

        public override void PrepareMonthlyReport()
        {
            double interest = LowestBalance * INTEREST_RATE / 12;
            Balance -= interest;
            transactions.Clear();

        }

        //Mcdonalds
    }

    
}
