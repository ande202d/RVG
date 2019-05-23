
using System;
using System.Collections.Generic;
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

        
    }
}
