using System;

namespace Group_Project_for_Programming_2
{
using System;

    public class Person
    {
        private string password;
        public event EventHandler<LoginEventArgs> OnLogin;

        public string SIN { get; }
        public string Name { get; }
        public bool IsAuthenticated { get; private set; }

        public Person(string name, string sin)
        {
            Name = name;
            SIN = sin;
            password = SIN.Substring(0, 3);
        }

        public void Login(string password)
        {
            if (this.password != password)
            {
                IsAuthenticated = false;
                OnLogin?.Invoke(this, new LoginEventArgs(Name, false));
                throw new AccountException(ExceptionType.PASSWORD_INCORRECT);
            }

            IsAuthenticated = true;
            OnLogin?.Invoke(this, new LoginEventArgs(Name, true));
        }

        public void Logout()
        {
            IsAuthenticated = false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}