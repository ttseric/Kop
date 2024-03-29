﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Autofac;
using Autofac.Integration.Mvc;
using Kop.Core;
using Kop.Core.Data;
using Kop.Data;
using Kop.Services.Prayers;

namespace Kop.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IocConfig.Build();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            string roles = null;
            FormsIdentity identity = null;

            if (Context.Request.IsAuthenticated)  // authentication cookie presented
            {
                    identity = (FormsIdentity)Context.User.Identity;
                    roles = identity.Ticket.UserData;

                    Context.User = new GenericPrincipal(identity, roles.Split(','));
            }
        }
    }
}