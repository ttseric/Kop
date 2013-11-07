using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Data.Mapping.PrayerTemplates
{
    public class PrayerTemplateCategoryMap : EntityTypeConfiguration<PrayerTemplateCategory>
    {
        public PrayerTemplateCategoryMap()
        {
            Property(x => x.Name).HasMaxLength(10);
        }
    }
}
