using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kop.Core;
using Kop.Services.Bibles;
using Kop.Web.Models;

namespace Kop.Web.Controllers
{
    public class BibleController : Controller
    {
        private readonly IBibleService _bibleService;

        public BibleController(IBibleService bibleService)
        {
            _bibleService = bibleService;
        }

        [HttpGet]
        public ActionResult SearchBibleResult(string bookName, int chapter, int fromVerse, int toVerse)
        {
            var bibles = _bibleService.Search(bookName, chapter, fromVerse, toVerse);
            var model = new SearchBibleModel
                {
                    DisplayBibles = bibles,
                    BibleBooks = _bibleService.GetBibleBooks(),
                    Chatpers = _bibleService.GetChapters(bookName)
                };

            return View("ViewBible", model);
        }

        [HttpGet]
        public ActionResult ViewBible()
        {
            return View(new SearchBibleModel
                {
                    DisplayBibles = new List<Bible>(),
                    BibleBooks = _bibleService.GetBibleBooks(),
                    Chatpers = new List<int>()
                });
        }
    }
}
