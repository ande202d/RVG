using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVG.Model
{
    public class ArtefactCatalogSingleton
    {
        private List<Artefacts> _artefactslist;

        private ArtefactCatalogSingleton()
        {
            _artefactslist = new List<Artefacts>();
        }

        private static ArtefactCatalogSingleton _instance;

        public static ArtefactCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ArtefactCatalogSingleton();
                    return _instance;
                }
                else return _instance;
            }
        }

        public List<Artefacts> GetArtefacts
        {
            get { return _artefactslist; }
        }

        public void AddArtefact(Artefacts a)
        {
            _artefactslist.Add(a);
        }

        public void RemoveArtefact(Artefacts a)
        {
            _artefactslist.Remove(a);
        }



    }
}
