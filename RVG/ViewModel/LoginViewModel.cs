using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RVG.Annotations;
using RVG.Common;
using RVG.Model;
using RVG.View;

namespace RVG.ViewModel
{
    public class LoginViewModel:INotifyPropertyChanged
    {
        private Login _login;
        private string _input;
        private string _error;

        public LoginViewModel()
        {
            _login = new Login();

            //CheckCommand = new RelayCommand(CheckMethod);
        }

        //public ICommand CheckCommand { get; set; }

        public Login Login
        {
            get { return _login; }
        }

        public string Input
        {
            get { return _input;}
            set { _input = value; OnPropertyChanged(); }
        }

        public string Error
        {
            get { return _error; }
            set { _error = value; OnPropertyChanged(); }
        }

        //public void CheckMethod()
        //{
        //    if (_login.PasswordCheck(Input))
        //    {
        //        Error = "";
        //    }
        //    else
        //    {
        //       Error = "Forkert kode";
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
