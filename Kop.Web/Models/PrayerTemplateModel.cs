using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kop.Core;

namespace Kop.Web.Models
{
    public class PrayerTemplateModel
    {
        public List<PrayerTemplateCategory> PrayerTemplateCategories { get; set; }
        public List<PrayerTemplate> PrayerTemplates { get; set; }
        public PrayerTemplate PrayerTemplate { get; set; }
    }
}