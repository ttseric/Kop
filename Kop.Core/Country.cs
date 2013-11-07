using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kop.Core
{
    public class Country
    {
        public int CountryId { get; set; }
        public string NameChi { get; set; }
        public string NameEng { get; set; }
        public List<User> Users { get; set; }
    }
}
