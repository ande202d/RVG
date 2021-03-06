﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml.Controls;
using RVG.Annotations;
using RVG.Common;
using RVG.Model;


namespace RVG.ViewModel
{
    public class CatalogViewModel:INotifyPropertyChanged
    {
        private static ArtefactCatalogSingleton _catalog;
        private Artefacts _selectedArtefact;
        private MediaPlayer player;
        private bool playing = false;
        private string SoundCurrentName = "No Song Selected";

        #region Constructor

        public CatalogViewModel()
        {
            _catalog = ArtefactCatalogSingleton.Instance;
            player = new MediaPlayer();
            CreateTestArtefacts();

            //Kører en relayargcommand der sender artefact med som parameter.
            //Herefter kører vi en anonym funktion som parser valgte artefakt til LoadMethod
            LoadCommand = new RelayArgCommand<Artefacts>(artefacts => LoadMethod(artefacts));
            SoundPlayCommand = new RelayCommand(SoundPlayMethod);
            SoundPauseCommand = new RelayCommand(SoundPauseMethod);
            SoundStopCommand = new RelayCommand(SoundStopMethod);
            SoundChangeCommand = new RelayCommand(SoundChangeMethod);

            UpdateArtefactCommand = new RelayCommand(UpdateArtefactMethod);
            ResetArtefactCommand = new RelayCommand(ResetArtefactMethod);

        }

        #endregion

        #region Properties

        
        public Artefacts SelectedArtefact
        {
            get { return _selectedArtefact; }
            set { _selectedArtefact = value; OnPropertyChanged(); }
        }

        public string SoundCurrent
        {
            get { return SoundCurrentName; }
            set { SoundCurrentName = value; OnPropertyChanged(); }
        }

        public string SoundTimeEnd
        {
            get { return $"{player.Position.Duration()}";}
        }

        public string SoundTimeNow
        {
            get { return $"{player.Position.ToString()}"; }
        }

        public int AmountOfArtefacts
        {
            get { return _catalog.GetArtefacts.Count; }
        }

        

        #endregion

        #region Commands

        public ICommand LoadCommand { get; set; }

        public ICommand SoundPlayCommand { get; set; }
        public ICommand SoundPauseCommand { get; set; }
        public ICommand SoundStopCommand { get; set; }
        public ICommand SoundChangeCommand { get; set; }

        public ICommand UpdateArtefactCommand { get; set; }
        public ICommand ResetArtefactCommand { get; set; }



        #endregion

        #region Methods

        //En metode som opretter nogen dummy artefacts og efter en liste så vi i alt har 50 artefakter
        public void CreateTestArtefacts()
        {
            _catalog.AddArtefact(new Artefacts("art1", "art1.txt", "art1.mp3", 100, 100));
            _catalog.AddArtefact(new Artefacts("art2", "art2.txt", "art2.mp3", 200, 200));
            _catalog.AddArtefact(new Artefacts("art3", "art3.txt", "art3.mp3", 300, 100));
            _catalog.AddArtefact(new Artefacts("art4", "art4.txt", "art4.mp3", 400, 100));

            int maxValue = 50;
            int nowValue = _catalog.GetArtefacts.Count;

            for (int i = 0; (i + nowValue) < maxValue; i++)
            {
                _catalog.AddArtefact(new Artefacts());
            }
        }

        //Tager i mod typen artefakt i parameter, hvor den herefter sammenligner i vores artefaktliste efter det valgte artefaktid
        public void LoadMethod(Artefacts a)
        {
            SelectedArtefact = _catalog.GetArtefacts.Find(artefacts => a.ArtefactID.Equals(artefacts.ArtefactID));
        }

        //Her kan vi afspille den sang der er i fokus
        public void SoundPlayMethod()
        {
            player.Play();
        }

        //Her kan vi pause musiken
        public void SoundPauseMethod()
        {
            player.Pause();
        }
        //Her kan vi stoppe musiken
        public void SoundStopMethod()
        {
            player.Pause();
            player.Position = new TimeSpan(0,0,0,0);
        }
        //Her kan vi ændre hvilken sang der er i fokus af musik afspilleren
        public async void SoundChangeMethod()
        {
            if (SelectedArtefact != null)
            {
                if (File.Exists(SelectedArtefact.LydPath))
                {
                    //her laver vi en StorageFolder for at Filen senere ved hvilken Folder den skal lede i
                    Windows.Storage.StorageFolder folder =
                        await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Files");
                    //her bruger vi mappen, og leder efter en fil i mappen som matcher navnet på lydfilen.
                    Windows.Storage.StorageFile file = await folder.GetFileAsync(SelectedArtefact.LydFil);
                    //her sætter vi så den source som der skal afspilles
                    player.Source = MediaSource.CreateFromStorageFile(file);
                    SoundCurrent = SelectedArtefact.LydFil;
                }
            }
        }

        //Denne metode opdatere det valgte artefakt
        public void UpdateArtefactMethod()
        {
            _catalog.UpdateArtefact(SelectedArtefact);
            OnPropertyChanged(nameof(All_Artefacts));

        }

        //Denne metode resetter et artefakt
        public void ResetArtefactMethod()
        {
            SelectedArtefact.ArtefactName = "";
            SelectedArtefact.TextFil = "";
            SelectedArtefact.LydFil = "";
            SelectedArtefact.Xpos = 5000;
            SelectedArtefact.Ypos = 0;
            OnPropertyChanged(nameof(AmountOfArtefacts));
            OnPropertyChanged(nameof(All_Artefacts));

        }

        #endregion

        public ObservableCollection<Artefacts> All_Artefacts
        {
            get
            {
                ObservableCollection<Artefacts> collection = new ObservableCollection<Artefacts>(_catalog.GetArtefacts);
                return collection;


            }
        }

        #region OnProperyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
