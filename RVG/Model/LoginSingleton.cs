using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using RVG.Persistency;

namespace RVG.Model
{
    public class LoginSingleton
    {      
        private List<AccessCodes> _codeList;
        private Random _generator;
        private FilePersistency<AccessCodes> _fileSource;

        private LoginSingleton()
        {
            _codeList = new List<AccessCodes>();
            _generator = new Random();
            //_codeList.Add(new AccessCodes("1234"));
            _fileSource = new FilePersistency<AccessCodes>();
        }

        private static LoginSingleton _instance;


        public static LoginSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoginSingleton();
                    return _instance;
                }
                else
                {
                    return _instance;
                }
            }
        }

        public List<AccessCodes> GetAccessCodes
        {
            get { return _codeList; }
            set { _codeList = value; }
        }

        public bool PasswordCheck(string input)
        {
            int sameDate = 0;
            int earlierDate = -1;
            int laterDate = 1;
            foreach (AccessCodes c in GetAccessCodes)
            {
                if (c.Code==input && sameDate==DateTime.Today.CompareTo(c.Timer))
                {
                    return true;
                }
            }

            return false;
        }

        public void GenerateAccessCode()
        {
            DateTime today = DateTime.Today;
            int tal1 = _generator.Next(0, 10);
            int tal2 = _generator.Next(0, 10);
            int tal3 = _generator.Next(0, 10);
            int tal4 = _generator.Next(0, 10);
            string Code = tal1.ToString() + tal2 + tal3 + tal4;
            bool exists = false;
            foreach (AccessCodes c in GetAccessCodes)
            {
                if (c.Code==Code)
                {
                    exists = true;
                }
            }

            if (GetAccessCodes.Count >= 9000)
            {
                goto end;
            }
            if (!exists)
            {
                _codeList.Add(new AccessCodes(Code, today));
            }
            else
            {
                GenerateAccessCode();
            }
        end:;

        }

        public async Task SaveAsync()
        {
            await _fileSource.SaveAsync(GetAccessCodes);
        }

        public async Task<List<AccessCodes>> LoadAsync()
        {
            GetAccessCodes = await _fileSource.LoadAsync();
            return GetAccessCodes;
        }

        public void DeleteCode(AccessCodes c)
        {
            if (GetAccessCodes.Contains(c))
            {
                GetAccessCodes.Remove(c);
                SaveAsync();
            }
        }
    }
}
