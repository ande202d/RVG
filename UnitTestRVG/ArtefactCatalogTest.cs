
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RVG;
using RVG.Model;

namespace UnitTestRVG
{
    [TestClass]
    public class ArtefactCatalogTest
    {
        private ArtefactCatalogSingleton ACS;
        private void Create()
        {
            ACS = ArtefactCatalogSingleton.Instance;
            Artefacts a1 = new Artefacts();
            Artefacts a2 = new Artefacts("navn", "art1.txt", "art1.mp3", 100, 100);
            Artefacts a3 = new Artefacts("Jacob", "art1.txt", "art1.mp3", 200, 200);

            ACS.AddArtefact(a1);
            ACS.AddArtefact(a2);
            ACS.AddArtefact(a3);
        }
        [TestMethod]
        public void AddArtefactTest()
        {
            //Arange
            Create();
            int Expected = 3;

            //Act

            //Assert
            Assert.AreEqual(Expected, ACS.GetArtefacts.Count);
        }

        [TestMethod]
        public void UpdateArtefactTest()
        {
            //Arange
            Create();
            Artefacts aa = ACS.GetArtefacts[0];

            //Act
            aa.ArtefactName = "hej";
            aa.TextFil = "hej";
            aa.LydFil = "hej";
            aa.Xpos = 100;
            aa.Ypos = 100;

            ACS.UpdateArtefact(aa);

            //Assert
            Assert.AreEqual("hej", ACS.GetArtefacts[0].TextFil);
        }

        [TestMethod]
        public void RemoveArtefactTest()
        {
            Create();
            int expected = ACS.GetArtefacts.Count - 1;
            ACS.RemoveArtefact(ACS.GetArtefacts[1]);
            Assert.AreEqual(expected, ACS.GetArtefacts.Count);
        }
    }
}
