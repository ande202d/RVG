using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVG.Model
{
    public class ArtefactCatalog
    {
        private List<Artefacts> _artefactslist;

        public ArtefactCatalog()
        {
            _artefactslist = new List<Artefacts>();
        }

        public List<Artefacts> GetArtefacts
        {
            get { return _artefactslist; }
        }

        public void AddArtefact(Artefacts a)
        {
            _artefactslist.Add(a);
        }

        public void UpdateArtefact(Artefacts a)
        {
            _artefactslist[_artefactslist.IndexOf(a)] = a;
        }

        public void RemoveArtefact(Artefacts a)
        {
            _artefactslist.Remove(a);
        }



    }
}
