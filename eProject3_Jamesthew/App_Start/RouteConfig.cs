using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eProject3_Jamesthew
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Login",
                url: "login/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Taxonomy",
                url: "Taxonomy/{action}/{type}||{id}",
                defaults: new { controller = "Taxonomy", action = "Index", type = "", id = ""}
            );

            routes.MapRoute(
                name: "Content",
                url: "Content/Data/{action}/{type}",
                defaults: new { controller = "Content", action = "Index", type = "" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
