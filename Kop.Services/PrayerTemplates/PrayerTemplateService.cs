using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;
using Kop.Core.Data;

namespace Kop.Services.PrayerTemplates
{
    public class PrayerTemplateService : IPrayerTemplateService
    {
        private readonly IRepository<PrayerTemplate> _prayerTemplateRepository;
        private readonly IRepository<PrayerTemplateCategory> _prayerTemplateCategoryRepository;

        public PrayerTemplateService(IRepository<PrayerTemplate> prayerTemplateRepository, IRepository<PrayerTemplateCategory> prayerTemplateCategoryRepository)
        {
            _prayerTemplateCategoryRepository = prayerTemplateCategoryRepository;
            _prayerTemplateRepository = prayerTemplateRepository;
        }

        public List<PrayerTemplate> GetPrayerTemplates(int categoryId)
        {
            return _prayerTemplateRepository.Table.Where(x=>x.PrayerTemplateCategory.PrayerTemplateCategoryId == categoryId)
                .Include("PrayerTemplateBibles")
                .Include("PrayerTemplateBibles.Bible")
                .Include("PrayerTemplateBibles.Bible.BibleBook")
                .ToList();
        }

        public List<PrayerTemplateCategory> GetPrayerTemplateCategories()
        {
            return _prayerTemplateCategoryRepository.Table.ToList();
        }

        public PrayerTemplate GetPrayerTemplate(int id)
        {
            return _prayerTemplateRepository.Table.First(x => x.PrayerTemplateId == id);
        }


        public PrayerTemplateCategory GetPrayerTemplateCategory(int categoryId)
        {
            return _prayerTemplateCategoryRepository.GetById(categoryId);
        }

        public void Insert(PrayerTemplate prayerTemplate)
        {
            _prayerTemplateRepository.Insert(prayerTemplate);
        }
    }
}
