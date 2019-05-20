using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store.Preview.InstallControl;

namespace RVG.Model
{
    public class AccessCodes
    {
        private string _code;
        private DateTime _timer;

        public AccessCodes(string code, DateTime timer)
        {
            _code = code;
            _timer = timer;
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public DateTime Timer
        {
            get { return _timer; }
        }

        public string Dato
        {
            get
            {
                string dato = Timer.ToString("d");
                return dato;
            }
        }

        public string GyldigColor
        {
            get
            {
                if (Timer == DateTime.Today)
                {
                    return "Green";
                }

                return "Red";
            }
        }
    }
}
