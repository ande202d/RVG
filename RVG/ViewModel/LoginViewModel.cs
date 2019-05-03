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
        private string _input;
        private string _error;

        #region Constructor

        public LoginViewModel()
        {
            Login = new Login();

            //CheckCommand = new RelayCommand(CheckMethod);
        }

        #endregion

        //public ICommand CheckCommand { get; set; }

        #region Properties

        public Login Login { get; }

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

        #endregion

        #region Methods

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

        #endregion

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
