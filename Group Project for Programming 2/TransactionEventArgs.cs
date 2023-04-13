using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
