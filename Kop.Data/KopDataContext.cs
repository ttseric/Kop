using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;
using Kop.Data.Mapping.Bibles;
using Kop.Data.Mapping.PrayerTemplates;
using Kop.Data.Mapping.Prayers;
using Kop.Data.Mapping.UserPrayers;
using Kop.Data.Mapping.Users;

namespace Kop.Data
{
    public class KopDataContext : DbContext
    {
        public DbSet<Prayer> Prayers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Bible> Bibles { get; set; }
        public DbSet<BibleBook> BibleBooks { get; set; }
        public DbSet<PrayerTemplate> PrayerTemplates { get; set; }
        public DbSet<PrayerTemplateCategory> PrayerTemplateCategories { get; set; }

        public KopDataContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChangeWithSeed());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var prayerMap = new PrayerMap();
            var userMap = new UserMap();
            var userPrayerMap = new UserPrayerMap();
            var prayerAnswerMap = new PrayerAnswerMap();
            var prayerTemplateMap = new PrayerTemplateMap();
            var bibleBookMap = new BibleBookMap();
            var bibleMap = new BibleMap();
            var prayerTemplateCategoryMap = new PrayerTemplateCategoryMap();

            modelBuilder.Configurations.Add(prayerMap);
            modelBuilder.Configurations.Add(userMap);
            modelBuilder.Configurations.Add(userPrayerMap);
            modelBuilder.Configurations.Add(prayerAnswerMap);
            modelBuilder.Configurations.Add(prayerTemplateMap);
            modelBuilder.Configurations.Add(bibleBookMap);
            modelBuilder.Configurations.Add(bibleMap);
            modelBuilder.Configurations.Add(prayerTemplateCategoryMap);

            base.OnModelCreating(modelBuilder);
        }
    }
}
