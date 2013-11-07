using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Data.Mapping.UserPrayers
{
    public class UserPrayerMap : EntityTypeConfiguration<UserPrayer>
    {
        public UserPrayerMap()
        {
            ToTable("UserPrayer");
            HasKey(x => x.UserPrayerId);            
        }
    }
}
