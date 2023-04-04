using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Group_Project_for_Programming_2
{
    abstract class Account
    {
        static private int LAST_NUMBER = 100_000;
        readonly List<Person> users = new List<Person>();
        readonly List<Transaction> transactions = new List<Transaction>();
        // you need to add an even called OnTransaction
        public event EventHandler OnTransaction;
        public string Number { get; }
        public double Balance { get; protected set; }
        public double LowestBalance { get; protected set; }
        public Account (string type, double balance)
        {

        }

        public void deposit(double balance, Person person)
        {

        }
        public void AddUser(Person person)
        {

        }
        public void IsUser(string name)
        {

        }
        // create virtual OnTransactionOccur( sender: object. args: Event Args)


    }
}
