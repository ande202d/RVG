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

//using System.Windows.Media;
//using MediaPlayer = System.Windows.Media.MediaPlayer;

namespace RVG
{
    public class Artefacts
    {
        //Har dannet instancefield
        private string _artefactName;
        private int _artefactId;
        private string _text;
        private string _textPath;
        private string _lydpath;

        //Dannet konstructor
        public Artefacts(string name, int ID, string TextPathh, string LydPathh)
        {
            _artefactName = name;
            _artefactId = ID;
            _textPath = TextPathh;
            _lydpath = LydPathh;

            //Kører en anonym funktion der henter tekst fra tekstfiler
            Task.Run(() => GetTextFile());



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
                Task.Run(() => GetTextFromFile());
                return _text;
            }
            set { _text = value; }
        }

        public string TextPath
        {
            get { return _textPath; }
            set { _textPath = value; }
        }

        public string LydPath
        {
            get { return _lydpath; }
            set { _lydpath = value; }
        }

        public string LydFil
        {
            get { return Path.GetFileName(LydPath); }
        }

        public void GetTextFile()
        {
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            

            //if (File.Exists(TextPath))
            //{
           // Debug.WriteLine();
                //Text = File.ReadAllText(TextPath);
            //}
        }

        public void GetTextFromFile()
        {
            _text = File.ReadAllText(TextPath);
        }



    }
}
