using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_for_Programming_2
{
    public class Person
    {// all of the fields are to the request of the proffesor and the methods are to the request of the proffesor
        private string Password;
        public event EventHandler OnLogin;
        public string Sin { get; }
        public string Name { get; }
        // the IsAuthenticaed will now wortk without a setter i have no idea why proff asked for no setter
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
