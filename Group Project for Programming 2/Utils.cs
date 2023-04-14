using System;
using System.Collections.Generic;

namespace Group_Project_for_Programming_2
{
    public static class Utils 
    {
        static DayTime _time = new DayTime(1_048_000_000);
        static Random random = new Random();
        public static DayTime Time => _time += random.Next(1000);

        public static DayTime Now => _time += 0;

        public static readonly Dictionary<AccountType, string> ACCOUNT_TYPES = 
            new Dictionary<AccountType, string>
        {
            { AccountType.Checking , "CK" },
            { AccountType.Saving , "SV" },
            { AccountType.Visa , "VS" }
        };

    }

}
