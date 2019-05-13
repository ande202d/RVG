using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RVG.Common;

namespace RVG.Model
{
    public class CRUD
    {

        private ArtefactCatalog _artefact;
        private Artefacts _newArtefact;

        public CRUD()
        {
            _artefact = new ArtefactCatalog();
            _newArtefact = new Artefacts();
            CreateArtefactCommand = new RelayCommand(toCreateArtefact);
            //UpdateArtefactCommand = new RelayCommand(toUpdateArtefact);
            //DeleteArtefactCommand = new RelayCommand(toDeleteArtefact);
        }


        #region Properties

        public Artefacts NewArtefact
        {
            get { return _newArtefact; }
            set { _newArtefact = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CreateArtefactCommand { get; set; }
        public RelayCommand UpdateArtefactCommand { get; set; }
        public RelayCommand DeleteArtefactCommand { get; set; }

        #endregion

        #region Methods

        public void toCreateArtefact()
        {
            _artefact.AddArtefact(NewArtefact);
        }

        #endregion


    }
}
