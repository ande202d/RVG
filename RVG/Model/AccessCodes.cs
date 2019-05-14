using System;
using System.Collections.Generic;
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

        public AccessCodes(string code)
        {
            _code = code;
            _timer = DateTime.Today;
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }


    }
}
