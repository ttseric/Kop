using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kop.Core
{
    public class PrayerAnswer
    {
        public int PrayerAnswerId { get; set; }
        public string Detail { get; set; }
        public DateTime CreateDate { get; set; }
        public int PraiseGodCount { get; set; }
        public Prayer Prayer { get; set; }
    }
}
