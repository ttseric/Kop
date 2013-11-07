using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Data.Mapping.Prayers
{
    public class PrayerMap : EntityTypeConfiguration<Prayer>
    {
        public PrayerMap()
        {
            ToTable("Prayer");
            HasKey(x => x.PrayerId);
            Property(x => x.SubmitDate).IsRequired();
            Property(x => x.From).IsRequired();
            Property(x => x.Support).IsRequired();
            HasRequired(x => x.RequestBy).WithMany(x => x.RequestPrayers);
            HasOptional(x => x.PrayerAnswer);
        }
    }
}
