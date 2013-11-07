using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Data.Mapping.PrayerTemplates
{
    public class PrayerTemplateMap : EntityTypeConfiguration<PrayerTemplate>
    {
        public PrayerTemplateMap()
        {
            HasKey(x => x.PrayerTemplateId);
            HasRequired(x => x.PrayerTemplateCategory).WithMany(x => x.PrayerTemplates).Map(x => x.MapKey("PrayerTemplateCategoryId"));
            HasMany(x => x.PrayerTemplateBibles).WithRequired(x => x.PrayerTemplate);
            Property(x => x.Detail).IsRequired();
            Property(x => x.Name).IsRequired().HasMaxLength(15);
        }
    }
}
