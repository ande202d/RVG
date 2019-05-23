
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RVG;
using RVG.Model;

namespace UnitTestRVG
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void GenerateCode()
        {
            //arrange
            LoginSingleton testLogin = LoginSingleton.Instance;
            int expectedResult = 1;

            //act
            testLogin.GenerateAccessCode();
            int actualresult = testLogin.GetAccessCodes.Count;

            //assert
            Assert.AreEqual(expectedResult,actualresult);
        }

        [TestMethod]
        public void GenerateCode_No_duplicates()
        {
            //arrange
            LoginSingleton testLogin = LoginSingleton.Instance;
            int expected = 1;
            int actual = 1;

            //act
            for (int i = 0; i < 10000; i++)
            {
                testLogin.GenerateAccessCode();
            }

            // if there's any duplicates
            if (testLogin.GetAccessCodes.Count != testLogin.GetAccessCodes.Distinct().Count())
            {
                actual = 0;
            }


            //assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void deletecode()
        {
            //arrange
            LoginSingleton testLogin = LoginSingleton.Instance;
            int expected = 0;
            AccessCodes testcode = new AccessCodes("1234", DateTime.Today);

            //act
            testLogin.GetAccessCodes.Add(testcode);
            testLogin.DeleteCode(testcode);
            int actual = testLogin.GetAccessCodes.Count;
            //assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void deletecode_that_doesnt_exist_on_list()
        {
            //arrange
            LoginSingleton testLogin = LoginSingleton.Instance;
            int expected = 1;
            AccessCodes testcode = new AccessCodes("1234", DateTime.Today);
            AccessCodes nolistCode = new AccessCodes("5616",DateTime.Today);

            //act
            testLogin.GetAccessCodes.Add(testcode);
            testLogin.DeleteCode(nolistCode);
            int actual = testLogin.GetAccessCodes.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
