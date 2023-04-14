using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_for_Programming_2
{
public class SavingAccount : Account, ITransaction
{
    private static double COST_PER_TRANSACTION = 0.5;
    private static double INTEREST_RATE = 0.015;

    public SavingAccount(double balance = 0, bool hasOverdraft = false) : base("SV-", balance, hasOverdraft)
    {
    }

    public new void Deposit(double amount, Person person)
    {
        base.Deposit(amount, person);
        OnTransactionOccur(new TransactionEventArgs(person.Name, amount, true));
    }

    public void Withdraw(double amount, Person person)
    {
        if (!IsPersonAssociated(person))
        {
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException("Person is not associated with this account.");
        }

        if (!person.IsLoggedIn)
        {
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException("Person is not logged in.");
        }

        if (amount > Balance && !HasOverdraft)
        {
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException("Insufficient balance.");
        }

        OnTransactionOccur(new TransactionEventArgs(person.Name, amount, true));
        base.Deposit(-amount, person);
    }

    public override void PrepareMonthlyReport()
    {
        double serviceCharge = Transactions.Count * COST_PER_TRANSACTION;
        double interest = LowestBalance * INTEREST_RATE / 12;
        Balance += interest - serviceCharge;
        Transactions.Clear();
    }
}
}
