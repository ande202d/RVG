using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using RVG.Annotations;
using RVG.Common;
using RVG.Model;
using RVG.View;

namespace RVG.ViewModel
{
    public class LoginViewModelSingleton:INotifyPropertyChanged
    {
        private string _gyldigcolor;

        #region Constructor

        public LoginViewModelSingleton()
        {
            LoginSingleton = LoginSingleton.Instance;

            //CheckCommand = new RelayCommand(CheckMethod);
            GenerateCommand = new RelayCommand(GenerateMethod);
            //SaveCommand = new RelayCommand(SaveMethod);
            LoadCommand=new RelayCommand(Load);
            DeleteCommand=new RelayCommand(DeleteOldCodes);
            Load();
        }

        #endregion

        //public ICommand CheckCommand { get; set; }
        public ICommand GenerateCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        //public RelayCommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        #region Properties

        public LoginSingleton LoginSingleton { get; }

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

        private void GenerateMethod()
        {
            LoginSingleton.GenerateAccessCode(); OnPropertyChanged(nameof(All_AccessCodes));
            LoginSingleton.SaveAsync();
        }

        //public void SaveMethod()
        //{
        //    LoginSingleton.SaveAsync();

        //}

        private void Load()
        {
            LoginSingleton.LoadAsync(); OnPropertyChanged(nameof(All_AccessCodes));
        }

        private void DeleteOldCodes()
        {
            foreach (AccessCodes c in All_AccessCodes)
            {
                if (c.Timer != DateTime.Today)
                {
                    LoginSingleton.DeleteCode(c); OnPropertyChanged(nameof(All_AccessCodes));
                }
            }

            LoginSingleton.SaveAsync();
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
