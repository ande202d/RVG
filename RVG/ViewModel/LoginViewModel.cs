using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RVG.Common;
using RVG.Model;

namespace RVG.ViewModel
{
    public class LoginViewModel
    {
        private Login _login;

        public LoginViewModel()
        {
            _login = new Login();

            //CheckCommand = new RelayCommand(CheckMethod);
        }

        public ICommand CheckCommand { get; set; }

        //public string SelectedInput { get { return  } }

        //public void CheckMethod()
        //{
        //    if (_login.PasswordCheck())
        //    {
        //        //reee//
        //    }
        //    else
        //    {

        //    }
        }
    }
}
