using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_for_Programming_2
{
    public class Person
    {
        private string Password;
        public event EventHandler OnLogin;
        public string Sin { get; }
        public string Name { get; }
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
        {
            IsAuthenticated = false;
        }
        public override string ToString()
        {
            return $"Your Name is {Name}";
        }
    }

}
