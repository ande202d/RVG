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
    public class CatalogViewModel:INotifyPropertyChanged
    {
        private ArtefactCatalog _catalog;
        private MediaElement _media;
        private Artefacts _selectedArtefact;
        private MediaPlayer _player;
        private bool _playing = false;
        #region Constructor

        public CatalogViewModel()
        {
            _catalog = new ArtefactCatalog();
            _catalog.AddArtefact(new Artefacts("art1", 1, "../../../../Files/textfil1(ungdomskultur).txt", @"../../../../Files/lydfil1.wav"));
            _catalog.AddArtefact(new Artefacts("art2", 2, "../../../../Files/textfil1(ungdomskultur).txt", @"../../../..\Files\SampleAudio_0.4mb.mp3"));
            _catalog.AddArtefact(new Artefacts("art3", 3, "../../../../Files/textfil1(ungdomskultur).txt", @"../../../..\Files\SampleAudio_0.7mb.mp3"));
            //@"../Files/textfil1(ungdomskultur).txt"
            //Path h = "../ Files / textfil1(ungdomskultur).txt";
            _media = new MediaElement();
            //Kører en relayargcommand der sender artefact med som parameter. Herefter kører vi en anonym funktion som parser valgte artefakt til LoadMethod
            LoadCommand = new RelayArgCommand<Artefacts>(artefacts => LoadMethod(artefacts));
            PlayCommand = new RelayCommand(PlayMethod);
            _player = new MediaPlayer();
            
        }

        #endregion

        #region Properties

        
        public Artefacts SelectedArtefact
        {
            get { return _selectedArtefact; }
            set { _selectedArtefact = value; OnPropertyChanged(); }
        }

        #endregion


        #region Commands

        public ICommand LoadCommand { get; set; }

        public ICommand PlayCommand { get; set; }


        #endregion

        #region Methods

        //Tager i mod typen artefakt i parameter, hvor den herefter sammenligner i vores artefaktliste efter det valgte artefaktid
        public void LoadMethod(Artefacts a)
        {
            SelectedArtefact = _catalog.GetArtefacts.Find(artefacts => a.ArtefactID.Equals(artefacts.ArtefactID));
        }

        public async void PlayMethod()
        {
            //_media.Source = new Uri("http://file-examples.com/wp-content/uploads/2017/11/file_example_WAV_1MG.wav"); /*= new Uri(SelectedArtefact.LydPath);*/
            //_media.Play();


            
                Windows.Storage.StorageFolder folder =
                    await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Files");
                Windows.Storage.StorageFile file = await folder.GetFileAsync(/*"lydfil1.wav"*/SelectedArtefact.LydFil);

                _player.Source = MediaSource.CreateFromStorageFile(file);

                if (_playing)
                {
                    _player.Source = null;
                    _playing = false;
                }
                else
                {
                    _player.Play();
                    _playing = true;
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
