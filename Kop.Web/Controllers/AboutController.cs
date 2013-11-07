using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kop.Web.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Introduction()
        {
            return View();
        }

    }
}
