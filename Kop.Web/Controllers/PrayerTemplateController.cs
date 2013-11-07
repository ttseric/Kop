using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kop.Core;
using Kop.Services.Bibles;
using Kop.Services.PrayerTemplates;
using Kop.Web.Models;

namespace Kop.Web.Controllers
{
    public class PrayerTemplateController : Controller
    {
        private readonly IPrayerTemplateService _prayerTemplateService;
        private readonly IBibleService _bibleService;

        public PrayerTemplateController(IPrayerTemplateService prayerTemplateService, IBibleService bibleService)
        {
            _bibleService = bibleService;
            _prayerTemplateService = prayerTemplateService;
        }


        public ActionResult PrayerTemplate(int prayerTemplateId)
        {
            var model = new PrayerTemplateModel();
            model.PrayerTemplateCategories = _prayerTemplateService.GetPrayerTemplateCategories();
            model.PrayerTemplate = _prayerTemplateService.GetPrayerTemplate(prayerTemplateId);
            model.PrayerTemplates = _prayerTemplateService.GetPrayerTemplates(model.PrayerTemplate.PrayerTemplateCategory.PrayerTemplateCategoryId);

            return View("PrayerTemplates", model);

        }
        public ActionResult PrayerTemplates(int categoryId)
        {
            var model = new PrayerTemplateModel();
            model.PrayerTemplateCategories = _prayerTemplateService.GetPrayerTemplateCategories();
            model.PrayerTemplates = _prayerTemplateService.GetPrayerTemplates(categoryId);

            return View("PrayerTemplates", model);
        }

        public ActionResult Categories()
        {
            var model = new PrayerTemplateModel();

            model.PrayerTemplateCategories = _prayerTemplateService.GetPrayerTemplateCategories();
            model.PrayerTemplates = new List<PrayerTemplate>();

            return View("PrayerTemplates", model);
        }

        public ActionResult CreatePrayerTemplate()
        {
            var model = new CreatePrayerTemplateModel();

            model.PrayerTemplateCategories = _prayerTemplateService.GetPrayerTemplateCategories()
                                            .Select(x => new SelectListItem { Text = x.Name, Value = x.PrayerTemplateCategoryId.ToString() })
                                            .ToList();

            model.BibleBooks = _bibleService.GetBibleBooks()
                                            .Select(x => new SelectListItem { Text = x.NameChi, Value = x.BibleBookId.ToString() })
                                            .ToList();

            return View("CreatePrayerTemplate", model);
        }

        public ActionResult SubmitPrayerTemplate(CreatePrayerTemplateModel model)
        {
            var prayerTemplate = new PrayerTemplate();

            prayerTemplate.PrayerTemplateCategory =
                _prayerTemplateService.GetPrayerTemplateCategory(model.SelectedCategory);
            prayerTemplate.Detail = model.Detail;
            prayerTemplate.Name = model.Name;
            prayerTemplate.Introduction = model.Introduction;

            if (string.IsNullOrEmpty(model.SelectedBible) == false)
            {
                var selectedBibleId = model.SelectedBible.Split(',');

                foreach (var bibleId in selectedBibleId)
                {
                    if (string.IsNullOrEmpty(bibleId) == false)
                    {
                        var ptb = new PrayerTemplateBible();

                        ptb.Bible = _bibleService.GetBible(Convert.ToInt32(bibleId));
                        ptb.PrayerTemplate = prayerTemplate;

                        prayerTemplate.PrayerTemplateBibles.Add(ptb);
                    }
                }
            }

            _prayerTemplateService.Insert(prayerTemplate);

            return RedirectToAction("CreatePrayerTemplate");
        }

        public JsonResult GetChapter(int bibleBookId)
        {
            var chapters = _bibleService.GetChapters(bibleBookId).OrderBy(x => x);

            return Json(new SelectList(chapters), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVerse(int chapter, int bibleBookId)
        {
            var verses = _bibleService.GetBible(bibleBookId, chapter);

            return Json(new SelectList(verses, "BibleId", "Verse"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBible(int bibleId)
        {
            var bible = _bibleService.GetBible(bibleId);

            return Json(new BibleModel
                {
                    BibleId = bible.BibleId,
                    BibleBookNameChiAbbr = bible.BibleBook.NameChiAbbr,
                    Chapter = bible.Chapter,
                    Text = bible.Text,
                    Verse = bible.Verse
                }, JsonRequestBehavior.AllowGet);
        }
    }
}
