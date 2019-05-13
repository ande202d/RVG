using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class LoginViewModelSingleton:INotifyPropertyChanged
    {
        private string _input;
        private string _error;

        #region Constructor

        public LoginViewModelSingleton()
        {
            LoginSingleton = LoginSingleton.Instance;

            //CheckCommand = new RelayCommand(CheckMethod);
            GenerateCommand = new RelayCommand(GenerateMethod);
        }

        #endregion

        //public ICommand CheckCommand { get; set; }
        public ICommand GenerateCommand { get; set; }

        #region Properties

        public LoginSingleton LoginSingleton { get; }

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

        public ObservableCollection<AccessCodes> All_AccessCodes
        {
            get
            {
                ObservableCollection<AccessCodes> collections = new ObservableCollection<AccessCodes>(LoginSingleton.GetAccessCodes);
                return collections;

            }
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

        public void GenerateMethod()
        {
            LoginSingleton.GenerateAccessCode(); OnPropertyChanged(nameof(All_AccessCodes));
        }

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
