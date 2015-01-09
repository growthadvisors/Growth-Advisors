using System.Web.Mvc;
using System.Web.Routing;

namespace GrowthAdvisors
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add(
                new Route(
                    "{controller}/{action}/{id}",
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Home",
                            action = "Index",
                            id = UrlParameter.Optional
                        }),
                        new HyphenatedRouteHandler())
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}