using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using System.Media;

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
        //private System.Media.SoundPlayer _afspiller;


        //Dannet konstructor
        public Artefacts(string name, int ID, string TextPath, string LydPath)
        {
            _artefactName = name;
            _artefactId = ID;
            _textPath = TextPath;
            _lydpath = LydPath;

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





    }
}
