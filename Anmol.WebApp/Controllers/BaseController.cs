using _Anmol.Common;
using _Anmol.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _Anmol.WebApp.Controllers
{
    public class BaseController : Controller
    {
        #region

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = System.Web.HttpContext.Current;
            string ControllerName = filterContext.Controller.ToString().ToLower();
            string ActionName = filterContext.ActionDescriptor.ActionName.ToString().ToLower();
            
            if (SessionHelper.UserId <= 0)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new HttpStatusCodeResult(401, "Unauthorized, Access Denied!");
                }
                else
                {
                    string url = filterContext.HttpContext.Request.RawUrl.ToString();
                    if (url.ToLower().IndexOf("Login") == -1 && url != "/")
                    {
                        TempData["ReturnURLUser"] = url;
                    }
                    else
                    {
                        TempData["ReturnURLUser"] = "";
                    }
                    filterContext.Result = new RedirectResult("~/Login");
                }
                return;
            }
            if (!AuthorizationHelper.IsAuthorized(filterContext))
            {
                filterContext.Result = new HttpStatusCodeResult(401, "Unauthorized, Access Denied!");
            }
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
            base.OnActionExecuting(filterContext);
        }

        #endregion
    }
}