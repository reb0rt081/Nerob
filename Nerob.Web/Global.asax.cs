﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Nerob.Web.App_Start;

namespace Nerob.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            WebLoader();
        }

        protected void WebLoader()
        {
            PickingControllerActivator pickingControllerActivator = new PickingControllerActivator();
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), pickingControllerActivator);
        }
    }
}
