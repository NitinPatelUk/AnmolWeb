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
    public class DailyMilkDeliveryController : Controller
    {
        // GET: DailyMilkDelivery
        public ActionResult Index()
        {
            ViewBag.GetDailyDeliveryList = DataSourceHelper.GetDailyDeliveryList();
            return View();
        }

        public async Task<ActionResult> GetDailyDeliveryList(string CustName,DateTime? FromDate,DateTime? ToDate)
        {

            var result = new ApiResponse<DailyMilkDelivery>();
            var uri = "GetDailyDeliveryList?CustName="+ CustName +"&FromDate=" + FromDate + "&ToDate=" + ToDate;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.Index, ControllerHelper.DailyMilkDelivery);
            }
        }
    }
}