using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RVG.Model
{
    public class SoundPlayer
    {
        private MediaElement _mediaElement;
        private string _path;

        public SoundPlayer()
        {
            _mediaElement = new MediaElement();
        }

        public void SetPath(string p)
        {
            _path = p;
        }

        public void PlaySound()
        {
            _mediaElement.Source = new Uri(@_path);
        }


    }
}
