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
    public class MilkOrderDetailsController : Controller
    {
        // GET: MilkOrderDetails
        public ActionResult GetMilkOrderDetail()
        {
            return View();
        }

        public async Task<ActionResult> GetMilkOrderList()
        {
            var model = new CustomerMilkOrderModel();
            var result = new ApiResponse<CustomerMilkOrderModel>();
            var uri = "GetMilkOrderList?CustId=" + SessionHelper.UserId;
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

        public async Task<ActionResult> SaveTemporaryMilkOrder(int CustTempOrdId, string FromDate, string ToDate, decimal Quantity, string Reason)
        {            
            try
            {
                CustomerMilkOrderModel model = new CustomerMilkOrderModel();
                model.CustTempOrdId = CustTempOrdId;
                model.CustID = SessionHelper.UserId;
                model.FromDate = Convert.ToDateTime(FromDate);
                model.ToDate = Convert.ToDateTime(ToDate);
                model.TemporaryOrder = Quantity;
                model.Reason = Reason;
                model.LoggedinUserName = SessionHelper.LoggedInUserName;
                var url = "SaveCustomerTemporaryMilkOrder";
                var response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<CustomerMilkOrderModel>, CustomerMilkOrderModel>(model, url, SessionHelper.AuthToken);
                return Json(new { Flag = response.Success }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

    }
}