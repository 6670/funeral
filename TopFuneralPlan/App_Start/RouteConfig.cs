using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TopFuneralPlan
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "BurialPlan",
                url: "burial-plan",
                defaults: new { controller = "Home", action = "BurialPlan" }
            );

            routes.MapRoute(
                name: "FuneralCosts",
                url: "funeral-costs",
                defaults: new { controller = "Home", action = "FuneralCosts" }
            );

            routes.MapRoute(
                name: "Over50sFuneralPlan",
                url: "over50s-funeral-plan",
                defaults: new { controller = "Home", action = "Over50sFuneralPlan" }
            );

            routes.MapRoute(
                name: "FuneralInsurance",
                url: "funeral-insurance",
                defaults: new { controller = "Home", action = "FuneralInsurance" }
            );

            routes.MapRoute(
                name: "FuneralCover",
                url: "funeral-cover",
                defaults: new { controller = "Home", action = "FuneralCover" }
            );

            routes.MapRoute(
                name: "FuneralPlan",
                url: "funeral-plan",
                defaults: new { controller = "Home", action = "FuneralPlan" }
            );

            routes.MapRoute(
                name: "contactus",
                url: "contact-us",
                defaults: new { controller = "Home", action = "contactus" }
            );

         

            routes.MapRoute(
                name: "thankyou",
                url: "thank-you",
                defaults: new { controller = "thank", action = "index" }
            );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
