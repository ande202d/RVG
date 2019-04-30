using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private Artefacts _selectedArtefact;
        private ArtefactCatalog _catalog;

        #region Constructor

        public CatalogViewModel()
        {
            _catalog = new ArtefactCatalog();
            //_selectedArtefact = new Artefacts("TestNavn", 999, "", "");

            _catalog.AddArtefact(new Artefacts("art1", 1, "../../../../Files/textfil1(ungdomskultur).txt", @"..\Files\SampleAudio_0.4mb.mp3"));
            _selectedArtefact = _catalog.GetArtefacts[0];
            //@"../Files/textfil1(ungdomskultur).txt"
            //Path h = "../ Files / textfil1(ungdomskultur).txt";
            Load1Command = new RelayCommand(Load1Method);
            /*Load2Command = new RelayCommand(Load2Method);
            Load3Command = new RelayCommand(Load3Method);*/
        }

        #endregion

        #region Properties

        public string SelectedText { get { return _selectedArtefact.Text; } }
        public string SelectedName { get { return _selectedArtefact.ArtefactName; } }
        public string SelectedLydPath { get { return _selectedArtefact.LydPath; } }

        #endregion


        #region Commands

        public ICommand Load1Command { get; set; }
        public ICommand Load2Command { get; set; }
        public ICommand Load3Command { get; set; }

        #endregion

        #region Methods

        public void Load1Method()
        {
            _selectedArtefact = _catalog.GetArtefacts[0];
            OnPropertyChanged(nameof(All_Artefacts));
        }
        /*public void Load2Method() {_selectedArtefact = _catalog.getList[0]; }
        public void Load3Method() {_selectedArtefact = _catalog.getList[0]; }*/




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
