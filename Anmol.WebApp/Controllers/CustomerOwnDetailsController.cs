using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.WebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _Anmol.WebApp.Controllers
{
    public class CustomerOwnDetailsController : Controller
    {
        // GET: CustomerDetails
        public async Task<ActionResult> Index()
        {
            int CustID = SessionHelper.UserId;
            var result = new ApiResponse<CustomerOwnDetailsModel>();
            var uri = "GetCustomerOwnDetails?CustID=" + CustID;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.GetCustomerOwnDetails, ControllerHelper.CustomerOwnDetails);
            }

        }

        public async Task<ActionResult> GetCustomerOwnDetails()
        {
            return View();
        }

    }
}