using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kop.Core;
using Kop.Services.Countries;
using Kop.Services.Prayers;
using Kop.Services.Users;
using Kop.Web.Models;

namespace Kop.Web.Controllers
{
    public class PrayerController : Controller
    {
        private User _user;
        private readonly IPrayerService _prayerService;
        private readonly IUserService _userService;
        private readonly IWebHelper _webHelper;
        

        public PrayerController(IPrayerService prayerService, IUserService userService, IWebHelper webHelper)
        {
            _webHelper = webHelper;
            _prayerService = prayerService;
            _userService = userService;

            if (_webHelper.RequestIsAuthenticated == false)
            {
                _user = _userService.GetAnonymousUser();
            }
            else
            {
                _user = _userService.GetByName(_webHelper.UserIdentityName);
            }

        }

        public ActionResult ViewPrayersWithModel(ViewPrayersModel model)
        {
            return View("ViewPrayers",model);
        }

        public ActionResult ViewPrayers()
        {
            var prayers = _prayerService.GetPrayers().OrderByDescending(x => x.SubmitDate);
            var model = new ViewPrayersModel(prayers);

            return View(model);
        }

        public ActionResult ViewPrayer(int prayerId)
        {
            var prayer = _prayerService.GetPrayer(prayerId);
            var model = new ViewPrayerModel(prayer);

            return View(model);

        }

        public ActionResult SupportPrayer(int id)
        {
            _prayerService.SupportPrayer(id, _user.UserId);

            return RedirectToAction("ViewPrayers");
        }

        public int PraiseGodAjax(int prayerId)
        {
            _prayerService.PraiseGod(prayerId);

            var prayer = _prayerService.GetPrayer(prayerId);

            return prayer.PrayerAnswer.PraiseGodCount;
        }

        public int SupportPrayerAjax(int prayerId)
        {
            _prayerService.SupportPrayer(prayerId, _user.UserId);

            var prayer = _prayerService.GetPrayer(prayerId);

            return prayer.Support;
        }
    }
}
