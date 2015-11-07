using ExportPlatform.DataAccess;
using System;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ExportPlatform
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            using (var context = new DataContext())
            {
                context.Logs.Add(new Log
                {
                    Created = DateTime.Now,
                    Email = "unknown",
                    Title = exception.Message,
                    Message = exception.StackTrace
                });
                context.SaveChanges();
            }
            Server.ClearError();
        }
    }
}
