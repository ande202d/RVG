using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Security;
using FileAttributes = System.IO.FileAttributes;
using System.Windows.Input;
using RVG.Common;
using RVG.ViewModel;

namespace RVG
{
    public class Artefacts
    {
        //Har dannet instancefield
        private string _artefactName;
        private static int _idCounter = 1;
        private int _artefactId;
        private string _text;
        private string _textPath;
        private string _lydpath;

        private string _lydfil;
        private string _textfil;
        private string _fileFolder = "../../../../Files/";
        private int _xPos;
        private int _yPos;

        public Artefacts(string name, string textfil, string lydfil, int xPos, int yPos)
        {
            _artefactName = name;
            _artefactId = _idCounter; _idCounter++;
            _textfil = textfil;
            _lydfil = lydfil;
            _xPos = xPos;
            _yPos = yPos;
        }

        public Artefacts()
        {
            _artefactName = "";
            _artefactId = _idCounter; _idCounter++;
            _textfil = "";
            _lydfil = "";
            _xPos = 5000;
            _yPos = 0;
        }

        //Dannet properties 
        public string ArtefactName
        {
            get { return _artefactName; }
            set { _artefactName = value; }
        }

        public int ArtefactID
        {
            get { return _artefactId; }
            set { _artefactId = value; }
        }

        public string Text
        {
            get
            {
                //Kører en anonym funktion der henter tekst fra tekstfiler og sætter det i _text
                Task.Run(() => GetTextFromFile());
                return _text;
            }
            set { _text = value; }
        }

        public string TextPath
        {
            get { return _fileFolder + _textfil; }
            set { _textPath = value; }
        }

        public string TextFil
        {
            get { return _textfil; }
            set { _textfil = value; }
        }



        public string LydPath
        {
            get { return _fileFolder + _lydfil; }
            set { _lydpath = value; }
        }

        public string LydFil
        {
            get { return _lydfil; }
            set { _lydfil = value; }
        }

        public int Xpos
        {
            get { return _xPos; }
            set { _xPos = value; }
        }
        public int Ypos
        {
            get { return _yPos; }
            set { _yPos = value; }
        }



        public void GetTextFromFile()
        {
            if (File.Exists(TextPath)) _text = File.ReadAllText(TextPath);
        }

        

    }
}
