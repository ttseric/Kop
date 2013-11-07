using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kop.Core;
using Kop.Services.Prayers;
using Kop.Services.Users;
using Kop.Web.Models;

namespace Kop.Web.Controllers
{
    public class MyPrayerController : Controller
    {
        private User _user;
        private readonly IPrayerService _prayerService;
        private readonly IUserService _userService;
        private readonly IWebHelper _webHelper;


        public MyPrayerController(IPrayerService prayerService, IUserService userService, IWebHelper webHelper)
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
        [Authorize]
        public ActionResult ViewMyPrayer(int prayerId)
        {
            var prayer = _prayerService.GetPrayer(prayerId);
            var model = new ViewPrayerModel(prayer);

            return View(model);
        }

        [Authorize]
        public ActionResult ViewMySupportPrayer()
        {
            var user = _userService.GetByIdIncludeAll(_user.UserId);
            var model = new ViewPrayersModel(user.SupportingPrayers.Select(x => x.Prayer));

            return View(model);
        }

        [Authorize]
        public ActionResult ViewMyPrayers()
        {
            var user = _userService.GetByIdIncludeAll(_user.UserId);
            var model = new ViewPrayersModel(user.RequestPrayers.OrderByDescending(x => x.SubmitDate));

            return View(model);
        }

        [Authorize]
        public ActionResult WritePrayerAnswer(int prayerId)
        {
            var prayer = _prayerService.GetPrayer(prayerId);
            var model = new WritePrayerAnswerModel(prayer);

            if (_webHelper.UserIdentityName != prayer.RequestBy.Name)
                return View("Unauthorized");

            return View(model);
        }

        [HttpPost]
        public ActionResult SubmitPrayerAnswer(WritePrayerAnswerModel model)
        {
            var prayer = _prayerService.GetPrayer(model.Id);

            if (prayer.PrayerAnswer == null)
            {
                prayer.PrayerAnswer = new PrayerAnswer();
                prayer.PrayerAnswer.CreateDate = DateTime.Now;
            }

            prayer.PrayerAnswer.Detail = model.PrayerAnswer;

            _prayerService.UpdatePrayer(prayer);

            return View("ViewMyPrayer", new ViewPrayerModel(prayer));
        }

    }
}
