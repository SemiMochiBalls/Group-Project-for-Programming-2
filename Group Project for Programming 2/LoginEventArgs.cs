using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_for_Programming_2
{
    public class LoginEventArgs : EventArgs
    {
        public string Name { get; }
        public bool Success { get; }

        public LoginEventArgs(string name, bool success)
        {
            Name = name;
            Success = success;
        }
    }
}
