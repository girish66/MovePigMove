using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MovePigMove.Core;
using MovePigMove.Core.StructureMap;

namespace MovePigMove.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            Bootstrapper.Start();
        }
    }
}