using _Anmol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _Anmol.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
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
            Exception exception = Server.GetLastError();
            Server.ClearError();
            Response.Clear();
            HttpContext.Current.ClearError();
            if (exception.Message.ToLower().Contains("jwt"))
            {

                Response.Redirect("~/Login");
            }
            else
            {
                if (SessionHelper.UserId > 0)
                {
                    if (SessionHelper.AuthToken == "")
                    {
                        Response.Redirect("~/Login");
                    }
                    else
                    {
                        Response.Redirect("~/Error_404");
                    }
                }
                else
                {
                    Response.Redirect("~/Login");
                }
            }
        }
    }
}
