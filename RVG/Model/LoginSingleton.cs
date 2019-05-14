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
        private string _password = "123456";
        
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

        public string Password
        {
            get { return _password;}
            set { _password = value; }
        }
        

        public bool PasswordCheck(string input)
        {
            foreach (AccessCodes c in GetAccessCodes)
            {
                if (c.Code==input && c.Timer==DateTime.Today)
                {
                    return true;
                }
            }

            return false;
            //if (Password == input)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public void GenerateAccessCode()
        {
            int tal1 = _generator.Next(0, 9);
            int tal2 = _generator.Next(0, 9);
            int tal3 = _generator.Next(0, 9);
            int tal4 = _generator.Next(0, 9);
            string Code = tal1.ToString() + tal2 + tal3 + tal4;
            bool exists = false;
            foreach (AccessCodes c in GetAccessCodes)
            {
                if (c.Code==Code)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                _codeList.Add(new AccessCodes(Code));
            }
            else
            {
                GenerateAccessCode();
            }
                    
            
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
