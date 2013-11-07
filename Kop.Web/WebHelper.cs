using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Kop.Core;

namespace Kop.Web
{
    public class WebHelper:IWebHelper
    {
        private readonly HttpContextBase _httpContext;

        public WebHelper(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public bool RequestIsAuthenticated
        {
            get { return _httpContext.Request.IsAuthenticated; }
        }

        public string UserIdentityName
        {
            get { return _httpContext.User.Identity.Name; }
        }


        public void SignIn(string name)
        {
            var now = DateTime.UtcNow.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                name,
                now,
                now.Add(new TimeSpan(0, 2, 0,0)),
                false,
                "user",
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }

            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }
            
            _httpContext.Response.Cookies.Add(cookie);            
        }


        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

    }
}