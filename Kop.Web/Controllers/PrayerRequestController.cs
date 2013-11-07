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
    public class PrayerRequestController : Controller
    {
        private User _user;

        private readonly IPrayerService _prayerService;
        private readonly IUserService _userService;
        private readonly IWebHelper _webHelper;
        private readonly ICountryService _countryService;

        public PrayerRequestController(IPrayerService prayerService, IUserService userService, ICountryService countryService, IWebHelper webHelper)
        {
            _webHelper = webHelper;
            _prayerService = prayerService;
            _userService = userService;
            _countryService = countryService;

            if (_webHelper.RequestIsAuthenticated == false)
            {
                _user = _userService.GetAnonymousUser();
            }
            else
            {
                _user = _userService.GetByName(_webHelper.UserIdentityName);
            }

        }

        public ActionResult PrayerRequest()
        {
            var model = new PrayerRequestModel();

            model.PrayBy = _user.Name;
            model.CountryList = _countryService.GetCountries().Select(x => new SelectListItem()
            {
                Selected = x.CountryId == _user.Country.CountryId,
                Value = x.NameChi,
                Text = x.NameChi
            }).ToList();

            return View(model);
        }

        public ActionResult SubmitPrayer(PrayerRequestModel model)
        {
            model.PrayBy = _user.Name;
            model.CountryList = _countryService.GetCountries().Select(x => new SelectListItem()
            {
                Selected = x.CountryId == _user.Country.CountryId,
                Value = x.NameChi,
                Text = x.NameChi
            }).ToList();

            if (!ModelState.IsValid)
                return View("PrayerRequest", model);

            var prayer = new Prayer();
            prayer.RequestBy = _user;
            prayer.SubmitDate = DateTime.Now;
            prayer.Detail = model.Detail;
            prayer.From = model.From;

            _prayerService.InsertPrayer(prayer);

            return RedirectToAction("ViewPrayers", "Prayer");
        }

    }
}
