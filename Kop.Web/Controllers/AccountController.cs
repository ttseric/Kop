using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Kop.Core;
using Kop.Services.Countries;
using Kop.Services.Users;
using Kop.Web.Models;

namespace Kop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHelper _webHelper;
        private readonly ICountryService _countryService;

        public AccountController(IUserService userService, ICountryService countryService, IWebHelper webHelper)
        {
            _countryService = countryService;
            _userService = userService;
            _webHelper = webHelper;
        }

        [HttpGet]
        public ActionResult Register()
        {
            var model = new RegisterModel();

            List<SelectListItem> listItems = _countryService.GetCountries().Select(x => new SelectListItem
                {
                    Value = x.CountryId.ToString(),
                    Text = x.NameChi
                }).ToList();

            model.CountryList = listItems;

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            List<SelectListItem> listItems = _countryService.GetCountries().Select(x => new SelectListItem
            {
                Value = x.CountryId.ToString(),
                Text = x.NameChi
            }).ToList();

            model.CountryList = listItems;

            if (ModelState.IsValid == false)
                return View(model);

            var user = new User
                {
                    Name = model.Name,
                    LoginName = model.LoginName,
                    Password = model.Password,
                    Country = _countryService.GetCountry(Convert.ToInt32(model.SelectedCountry))
                };

            _userService.InsertUser(user);

            _webHelper.SignIn(user.LoginName);

            return View("RegisterSuccess");
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var user = _userService.Login(model.LoginName, model.Password);

            if (user == null)
                return View("LoginFailure");

            _webHelper.SignIn(user.LoginName);

            return View("LoginSuccess");
        }

        public ActionResult Logout()
        {
            _webHelper.SignOut();

            return View("LogoutSuccess");
        }
    }
}
