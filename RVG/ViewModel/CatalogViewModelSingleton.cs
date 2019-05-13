using System;
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
    public class CatalogViewModelSingleton:INotifyPropertyChanged
    {
        private ArtefactCatalog _catalog;
        private Artefacts _selectedArtefact;
        private MediaPlayer player;
        private bool playing = false;
        private string SoundCurrentName = "No Song Selected";
        private static Artefacts _staticSelectedArtefacts;

        #region Constructor

        public CatalogViewModelSingleton()
        {
            _catalog = new ArtefactCatalog();
            player = new MediaPlayer();
            CreateTestArtefacts();

            //Kører en relayargcommand der sender artefact med som parameter.
            //Herefter kører vi en anonym funktion som parser valgte artefakt til LoadMethod
            LoadCommand = new RelayArgCommand<Artefacts>(artefacts => LoadMethod(artefacts));
            SoundPlayCommand = new RelayCommand(SoundPlayMethod);
            SoundPauseCommand = new RelayCommand(SoundPauseMethod);
            SoundStopCommand = new RelayCommand(SoundStopMethod);
            SoundChangeCommand = new RelayCommand(SoundChangeMethod);
        }

        #endregion

        #region Properties

        
        public Artefacts SelectedArtefact
        {
            get { return StaticSelectedArtefacts; }
            set { StaticSelectedArtefacts = value; OnPropertyChanged(); }
        }

        public static Artefacts StaticSelectedArtefacts
        {
            get
            {
                Debug.WriteLine("GET");
                return _staticSelectedArtefacts;
            }
            set
            {
                Debug.WriteLine("SET");
                _staticSelectedArtefacts = value; 
            }
        }

        public string SoundCurrent
        {
            get { return SoundCurrentName; }
            set { SoundCurrentName = value; OnPropertyChanged(); }
        }

        public string SoundTimeEnd
        {
            get { return $"{player.AutoPlay}";}
        }

        public string SoundTimeNow
        {
            get { return $"{player.Position.ToString()}"; }
        }

        

        #endregion

        #region Commands

        public ICommand LoadCommand { get; set; }

        public ICommand SoundPlayCommand { get; set; }
        public ICommand SoundPauseCommand { get; set; }
        public ICommand SoundStopCommand { get; set; }
        public ICommand SoundChangeCommand { get; set; }



        #endregion

        #region Methods

        //Laver nogle artefakts
        public void CreateTestArtefacts()
        {
            _catalog.AddArtefact(new Artefacts("art1", "art1.txt", "art1.mp3", 100, 100));
            _catalog.AddArtefact(new Artefacts("art2", "art2.txt", "art2.mp3", 200, 200));
            _catalog.AddArtefact(new Artefacts("art3", "art3.txt", "art3.mp3", 300, 100));
            _catalog.AddArtefact(new Artefacts("art4", "art4.txt", "art4.mp3", 400, 100));
        }

        //Tager i mod typen artefakt i parameter, hvor den herefter sammenligner i vores artefaktliste efter det valgte artefaktid
        public void LoadMethod(Artefacts a)
        {
            SelectedArtefact = _catalog.GetArtefacts.Find(artefacts => a.ArtefactID.Equals(artefacts.ArtefactID));
        }

        //TIMM - IKKE SLET
        //public static void OnClickSelectedArtefact(Artefacts a)
        //{
        //    StaticSelectedArtefacts = a;
        //}

        //Her kan vi afspille den sang der er i fokus
        public void SoundPlayMethod()
        {
            player.Play();
            //Debug.WriteLine($"{player.Position.Minutes} : {player.Position.Seconds}");
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
