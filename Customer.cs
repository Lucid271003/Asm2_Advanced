using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm2_Advanced
{
    internal class Customer : Admin
    {
        public Customer(string name, string password) : base(name, password) 
        {
            Name = name;
            Password = password;
        }

        public bool Authenticate(string enteredPassword)
        {
            return enteredPassword == Password;
        }
    }
}
