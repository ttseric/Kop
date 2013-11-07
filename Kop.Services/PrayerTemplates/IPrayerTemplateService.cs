using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Services.PrayerTemplates
{
    public interface IPrayerTemplateService
    {
        List<PrayerTemplate> GetPrayerTemplates(int categoryId);
        List<PrayerTemplateCategory> GetPrayerTemplateCategories();
        PrayerTemplate GetPrayerTemplate(int id);

        PrayerTemplateCategory GetPrayerTemplateCategory(int p);

        void Insert(PrayerTemplate prayerTemplate);
    }
}
