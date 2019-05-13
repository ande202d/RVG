using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RVG.ViewModel;
using Windows.Media.Playback;
using Windows.Media.Core;
using RVG.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RVG
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ArtefactCatalogSingleton ACS;
        private static int _buttonIdCounter = 1;
        private int _buttonId;
        public MainPage()
        {
            this.InitializeComponent();
            ACS = ArtefactCatalogSingleton.Instance;
            
            UpdateButtons();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = e.OriginalSource as Button;

            string hej = b.Name;
            
            CatalogViewModel.StaticSelectedArtefacts = ACS.GetArtefacts.Find(artefacts => hej.Equals(artefacts.ArtefactID.ToString()));
        }

        public void UpdateButtons()
        {
            Canvas c = new Canvas();
            foreach (Artefacts a in ACS.GetArtefacts)
            {
                Button b = new Button();
                b.Style = (Style)this.Resources["ArtefactButton"];
                //b.Margin = new Thickness{Left = a.Xpos, Top = a.Ypos};
                Canvas.SetLeft(b, a.Xpos + 50);
                Canvas.SetTop(b, a.Ypos);
                b.Content = $"{a.ArtefactID}xx";
                b.Name = a.ArtefactID.ToString();

                b.Click += Button_Click;
                //b.Click += new RoutedEventHandler();

                c.Children.Add(b);
            }
            StackPanelKort.Children.Add(c);
        }
    }
}
