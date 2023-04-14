using System;

namespace Group_Project_for_Programming_2
{
    public class Person
    {// all of the fields are to the request of the professor and the methods are to the request of the professor
        private string Password;
        public event EventHandler OnLogin;
        public string Sin { get; }
        public string Name { get; }
        // the IsAuthenticated will now work without a setter i have no idea why prof asked for no setter
        public bool IsAuthenticated { get; set; }
        public Person (string name, string sin)
        {
            Name = name;
            Sin = sin;
        }
        public void Login(string password)
        {
            if (password == Password) 
            {
                IsAuthenticated = true;
                // need to make EventHandler
            }
            else
            {   // implement EventHandler
                IsAuthenticated = false;
            }

        }
        public void Logout() 
        {// all this does is deauth the user
            IsAuthenticated = false;
        }
        public override string ToString()
        {// all this is meant to do is to return the name of the person
            return $"Your Name is {Name}";
        }
    }

}
