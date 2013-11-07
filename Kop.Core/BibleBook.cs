using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kop.Core
{
    public class BibleBook
    {
        public int BibleBookId { get; set; }
        public string Name { get; set; }        
        public int Index { get; set; }
        public string NameChi { get; set; }
        public string NameChiAbbr { get; set; }
        private List<Bible> _bibles = new List<Bible>(); 
        public List<Bible> Bibles
        {
            get { return _bibles; }
            set { _bibles = value; }
        }

        
    }
}
