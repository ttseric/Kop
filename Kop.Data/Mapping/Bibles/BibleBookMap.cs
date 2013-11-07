using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Data.Mapping.Bibles
{
    public class BibleBookMap : EntityTypeConfiguration<BibleBook>
    {
        public BibleBookMap()
        {
            HasKey(x => x.BibleBookId);
            HasMany(x => x.Bibles).WithRequired(x => x.BibleBook);
            Property(x => x.Index).IsRequired();
            Property(x => x.Name).IsRequired();
            Property(x => x.NameChi).IsRequired();
            Property(x => x.NameChiAbbr).IsRequired();
        }
    }
}
