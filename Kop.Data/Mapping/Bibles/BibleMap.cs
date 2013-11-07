using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Data.Mapping.Bibles
{
    public class BibleMap: EntityTypeConfiguration<Bible>
    {
        public BibleMap()
        {
            HasKey(x => x.BibleId);
            HasRequired(x => x.BibleBook).WithMany(x => x.Bibles).Map(x=>x.MapKey("BibleBookId"));
            Property(x => x.Chapter).IsRequired();
            Property(x => x.Verse).IsRequired();
            Property(x => x.Text).IsRequired();
        }
    }
}
