using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Data.Mapping.Prayers
{
    public class PrayerAnswerMap : EntityTypeConfiguration<PrayerAnswer>
    {
        public PrayerAnswerMap()
        {
            HasKey(x => x.PrayerAnswerId);
            Property(x => x.Detail).IsRequired();
            Property(x => x.PraiseGodCount).IsRequired();
            Property(x => x.PraiseGodCount).IsRequired();
            Property(x => x.CreateDate).IsRequired();
            HasRequired(x => x.Prayer).WithOptional(x => x.PrayerAnswer).Map(x => x.MapKey("PrayerId"));
        }
    }
}
