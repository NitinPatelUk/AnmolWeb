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
    public class DeliveryHistoryDetailsController : Controller
    {
        // GET: DeliveryHistoryDetails
        public ActionResult GetDeliveryHistory()
        {
            return View();
        }

        public async Task<ActionResult> GetCustomerMilkOrderHistory(string FromDate, string ToDate)
        {            
            var result = new ApiResponse<CustomerMilkOrderModel>();
            var uri = "GetCustomerMilkOrderHistory?CustId=" + SessionHelper.UserId + "&FromDate=" + FromDate + "&ToDate=" + ToDate;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.GetMilkOrderDetail, ControllerHelper.MilkOrderDetails);
            }
        }
    }
}