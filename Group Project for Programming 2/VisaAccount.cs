
namespace Group_Project_for_Programming_2
{
    class VisaAccount : Account, ITransaction
    {
        private double creditLimit;
        private const double INTEREST_RATE = 0.1995;
        //Hi future me you did a good job here be kind to yourself
        public VisaAccount(double balance = 0, double creditLimit = 1200)
            : base("VS-", balance)
        {
            this.creditLimit = creditLimit;
        }

        public void DoPayment(double amount, Person person)
        {
            Deposit(amount, person);
            OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }

        public void DoPurchase(double amount, Person person)
        {
            if (!IsAssociatedWithAccount(person))
            {
                OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }

            if (!IsLoggedIn(person))
            {
                OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(ExceptionType.USER_NOT_LOGGED_IN);
            }

            if (amount > Balance + creditLimit)
            {
                OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(ExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }

            Deposit(-amount, person);
            OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }

        public override void PrepareMonthlyReport()
        {
            double interest = LowestBalance * INTEREST_RATE / 12;
            Balance -= interest;
            transactions.Clear();

        }

        public void Withdraw(double amount, Person person)
        {
            throw new System.NotImplementedException();
        }
                    private bool IsAssociatedWithAccount(Person person)
            {
                    // Check if the person is associated with this account
                    // You can implement the logic here based on your requirements
                return true;
            }
            private bool IsLoggedIn(Person person)
            {
                    // Check if the person is logged in
                    // You can implement the logic here based on your requirements
                    return true;
            }

        //Mcdonalds
    }

    
}
