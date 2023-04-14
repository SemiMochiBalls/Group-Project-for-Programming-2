namespace Group_Project_for_Programming_2
{


    public class TransactionEventArgs : LoginEventArgs
    {
        public double Amount { get; }

        public TransactionEventArgs(string name, double amount, bool success) : base(name, success)
        {
            Amount = amount;
        }
    }

}
