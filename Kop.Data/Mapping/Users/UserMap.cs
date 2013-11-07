using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Data.Mapping.Users
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(x => x.UserId);
            Property(x => x.Name).IsRequired();
            Property(x => x.LoginName).IsRequired();
            Property(x => x.Name).HasMaxLength(100);
            HasRequired(x => x.Country).WithMany(x=>x.Users);
            HasMany(x => x.RequestPrayers).WithRequired(x => x.RequestBy);            
        }
    }
}
