using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVG.Model
{
    public class Login
    {
        private string _password = "1234";
        private string _input;

        public string Password
        {
            get { return _password;}
            set { _password = value; }
        }


        public bool PasswordCheck(string tekst)
        {
            if (Password == tekst)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
