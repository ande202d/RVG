﻿using System;
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
        //private MediaPlayer player;
        //private CatalogViewModel CVM;
        //CatalogViewModel cvm = new CatalogViewModel();
        public MainPage()
        {
            this.InitializeComponent();
            //UpdateButtons();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //public void UpdateButtons()
        //{

        //    foreach (Artefacts a in cvm.All_Artefacts)
        //    {
        //        string name = a.ArtefactID.ToString();
        //        Button b = new Button();
        //        b.Height = 50;
        //        b.Width = 50;
        //        b.Click += new RoutedEventHandler(UpdateButton_Click);

        //    }

        //    //   // < Button Margin = "0,0,0,0" Command = "{Binding LoadCommand}" CommandParameter = "{Binding All_Artefacts[ArtefactID-1]}" Style = "{StaticResource ArtefactButton}" Content = "{Binding ArtefactID}" HorizontalAlignment = "Left" VerticalAlignment = "Top" />
        //    //}

        //}

        //private void UpdateButton_Click(object sender, RoutedEventArgs e)
        //{
        //    //cvm.SelectedArtefact = e;
        //}
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
