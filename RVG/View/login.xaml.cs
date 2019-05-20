using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RVG.Model;
using RVG.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RVG.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class login : Page
    {
        public LoginViewModelSingleton LoginVMS { get; } = new LoginViewModelSingleton();

        public login()
        {
            this.InitializeComponent();
        }


        private void PassportSignInButton_Click_1(object sender, RoutedEventArgs e)
        {
            PasswordNavigation();

        }



        private void Input_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                PasswordNavigation();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(StartPage));
        }

        private void PasswordNavigation()
        {
            if (LoginVMS.LoginSingleton.PasswordCheck(Input.Text))
            {
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                ErrorMessage.Text = "Forkert kode";
                foreach (AccessCodes c in LoginVMS.All_AccessCodes)
                {
                    if (c.Code==Input.Text)
                    {
                        if (0 != DateTime.Today.CompareTo(c.Timer))
                        {
                            ErrorMessage.Text = "koden er udløbet";
                        }
                    }
                    
                }
            }
        }
    }
}
