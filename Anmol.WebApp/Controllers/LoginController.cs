using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _Anmol.WebApp.Common;
using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.Service;

namespace _Anmol.WebApp.Controllers
{

    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginUser(LoginModel model)
        {
            try
            {

                var response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<LoginModel>, LoginModel>(model, "LoginUser", SessionHelper.AuthToken);

                if (response != null && !response.Success)
                {
                    TempData["Error"] = response.Message.FirstOrDefault();
                    return View(ViewHelper.LoginView);
                }
                if (response.Success == true && response.Data.Count > 0)
                {
                    var objToken = new ApiPostResponse<string>();
                    var uri = "GetToken?EmailAddress=" + response.Data[0].EmailAddress;
                    objToken = await WebApiHelper.HttpClientRequestResponse(objToken, uri, "");
                    if (objToken != null && !string.IsNullOrEmpty(objToken.Data))
                    {
                        SessionHelper.AuthToken = objToken.Data;
                    }
                    var result = response.Data.FirstOrDefault();
                    if (result != null)
                    {
                        SessionHelper.UserId = result.UserId;
                        SessionHelper.LoggedInUserName = result.FullName;
                    }
                    await DataSourceHelper.SaveAuditTrail("Logged in into the system", "Login");
                }
                return RedirectToAction(ActionHelper.Index, ControllerHelper.User);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ViewHelper.LoginView);
            }
        }

        [AllowAnonymous]
        public async Task<ActionResult> Logout(LoginModel model)
        {
            this.Session.Abandon();
            await DataSourceHelper.SaveAuditTrail("Logged out from the system", "Logout");
            return RedirectToAction(ActionHelper.Index, ControllerHelper.Login);
        }

    }
}


