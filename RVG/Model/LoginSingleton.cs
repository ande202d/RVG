using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
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
                if (c.Code==input)
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
            _codeList.Add(new AccessCodes(Code));
        }

        public async Task SaveAsync()
        {
            await _fileSource.SaveAsync(_codeList);
        }

        public async Task<List<AccessCodes>> LoadAsync()
        {
            _codeList = await _fileSource.LoadAsync();
            return _codeList;
        }

    }
}
