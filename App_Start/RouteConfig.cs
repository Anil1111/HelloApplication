using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelloApplication
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GuestBook",
                url: "page/{page}",
                defaults: new { controller = "GuestBook", action = "Index" }
            );

            routes.MapRoute(
                name: "Paging",
                url: "{controller}/page/{page}",
                defaults: new { action = "Index" }
            );

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "GuestBook", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
