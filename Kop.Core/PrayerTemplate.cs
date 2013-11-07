using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kop.Core
{
    public class PrayerTemplate
    {
        public int PrayerTemplateId { get; set; }
        public PrayerTemplateCategory PrayerTemplateCategory { get; set; }
        private List<PrayerTemplateBible> _prayerTemplateBibles = new List<PrayerTemplateBible>();
        public string Detail { get; set; }
        public string Introduction { get; set; }
        public string Name { get; set; }
        public List<PrayerTemplateBible> PrayerTemplateBibles
        {
            get { return _prayerTemplateBibles; }
            set { _prayerTemplateBibles = value; }
        }
    }
}
