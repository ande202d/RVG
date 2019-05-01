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
using RVG.Annotations;
using RVG.Common;
using RVG.Model;

namespace RVG.ViewModel
{
    public class CatalogViewModel:INotifyPropertyChanged
    {
        private ArtefactCatalog _catalog;

        #region Constructor

        public CatalogViewModel()
        {
            _catalog = new ArtefactCatalog();
            _catalog.AddArtefact(new Artefacts("art1", 1, "../../../../Files/textfil1(ungdomskultur).txt", @"..\Files\SampleAudio_0.4mb.mp3"));
            _catalog.AddArtefact(new Artefacts("art2", 2, "../../../../Files/textfil1(ungdomskultur).txt", @"..\Files\SampleAudio_0.4mb.mp3"));
            _catalog.AddArtefact(new Artefacts("art3", 3, "../../../../Files/textfil1(ungdomskultur).txt", @"..\Files\SampleAudio_0.4mb.mp3"));
            //@"../Files/textfil1(ungdomskultur).txt"
            //Path h = "../ Files / textfil1(ungdomskultur).txt";

            //Kører en relayargcommand der sender artefact med som parameter. Herefter kører vi en anonym funktion som parser valgte artefakt til LoadMethod
            LoadCommand = new RelayArgCommand<Artefacts>(artefacts => LoadMethod(artefacts));
        }

        #endregion

        #region Properties

        private Artefacts _selectedArtefact;
        public Artefacts SelectedArtefact
        {
            get { return _selectedArtefact; }
            set { _selectedArtefact = value; OnPropertyChanged(); }
        }

        #endregion


        #region Commands

        public ICommand LoadCommand { get; set; }


        #endregion

        #region Methods

        //Tager i mod typen artefakt i parameter, hvor den herefter sammenligner i vores artefaktliste efter det valgte artefaktid
        public void LoadMethod(Artefacts a)
        {
            SelectedArtefact = _catalog.GetArtefacts.Find(artefacts => a.ArtefactID.Equals(artefacts.ArtefactID));
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
