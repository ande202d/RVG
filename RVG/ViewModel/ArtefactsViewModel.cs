﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class ArtefactsViewModel:INotifyPropertyChanged
    {
        private Artefacts _selectedArtefact;
        private Catalog _catalog;

        #region Constructor

        public ArtefactsViewModel()
        {
            _catalog = new Catalog();
            _catalog.AddArtefact(new Artefacts("art1", 1, @"\Files\textfil1(ungdomskultur).txt", @"\Files\SampleAudio_0.4mb.mp3"));


            ReadTextFileCommand = new RelayCommand(ReadTextFileMethod);
        }

        #endregion

        #region Commands

        public ICommand ReadTextFileCommand { get; set; }

        #endregion

        #region Methods

        public void ReadTextFileMethod()
        {

        }




        #endregion

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