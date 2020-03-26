using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace iSeriesAPIService
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "swagger/ui/index",
                defaults: new { controller = "Values", action = UrlParameter.Optional, id = UrlParameter.Optional }
            );
        }
    }
}
