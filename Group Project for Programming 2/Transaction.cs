namespace Group_Project_for_Programming_2
{
    public struct Transaction
    {
        public string AccountNumber { get; }
        public double Amount { get; }
        public Person Originator { get; }
        public DayTime Time { get; }

        public Transaction(string accountNumber, double amount, Person person)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = Utils.Time;
        }

        public override string ToString()
        {
            return $"Account Number: {AccountNumber}, Name: {Originator.Name}, Amount: {Amount:C}, Time: {Time}";
        }
    } 
    
}


