using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVG.Model
{
    public class Catalog
    {
        private List<Artefacts> _list;

        public Catalog()
        {
            _list = new List<Artefacts>();
        }

        public List<Artefacts> getList
        {
            get { return _list; }
        }

        public void AddArtefact(Artefacts a)
        {
            _list.Add(a);
        }

        public void RemoveArtefact(Artefacts a)
        {
            _list.Remove(a);
        }



    }
}
