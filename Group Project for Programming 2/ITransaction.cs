namespace Group_Project_for_Programming_2
{
    public interface ITransaction
    {
        void Withdraw(double amount, Person person);
        void Deposit(double amount, Person person);
        void DoPayment(double amount, Person person);

    }

}
