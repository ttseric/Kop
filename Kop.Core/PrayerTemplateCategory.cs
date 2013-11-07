using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kop.Core
{
    public class PrayerTemplateCategory
    {
        public int PrayerTemplateCategoryId { get; set; }
        public string Name { get; set; }
        private List<PrayerTemplate> _prayerTemplates = new List<PrayerTemplate>();
        public List<PrayerTemplate> PrayerTemplates
        {
            get { return _prayerTemplates; }
            set { _prayerTemplates = value; }
        }    
    }
}
