using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kop.Core
{
    public class PrayerTemplateBible
    {
        public int PrayerTemplateBibleId { get; set; }
        public PrayerTemplate PrayerTemplate { get; set; }
        public Bible Bible { get; set; }
    }
}
