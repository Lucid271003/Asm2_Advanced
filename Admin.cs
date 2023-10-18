using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm2_Advanced
{
    internal class Admin
    {
        private string name;
        private string password;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Password
        {
            get { return password; }
            set {  password = value; }
        }

        public Admin(string name, string password)
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
       
