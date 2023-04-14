using System;

namespace Group_Project_for_Programming_2
{
    class AccountException: Exception
        //Class is Child of Exception
    {
        public AccountException(ExceptionType reason) : base(reason.ToString()) { }
        //Returns exception to string when hit
    }
}
