
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RVG;
using RVG.Model;

namespace UnitTestRVG
{
    [TestClass]
    public class ArtefactCatalogTest
    {
        private void CreateObjects()
        {
            Artefacts a1 = new Artefacts();
            Artefacts a3;
            Artefacts a4 = new Artefacts("Jacob", "art1.txt", "art1.mp3", 200, 200);
        }

        [TestMethod]
        public void AddArtefactTest_Initialized()
        {
            //Arange
            ArtefactCatalogSingleton ACS = ArtefactCatalogSingleton.Instance;
            Artefacts a = new Artefacts("navn", "textfil", "lydfil", 100, 100);

            int Expected = 0;
            int Actual = 0;

            //Act
            ACS.AddArtefact(a);

            if (File.Exists(ACS.GetArtefacts[0].TextPath)) Actual += 0; else Actual += 1;
            if (File.Exists(ACS.GetArtefacts[0].LydPath)) Actual += 0; else Actual += 1;

            //Assert
            Assert.AreEqual(Expected, Actual, "Files does not exist");
        }

        [TestMethod]
        public void AddArtefactTest_UnInitialized()
        {

        }

    }
}
