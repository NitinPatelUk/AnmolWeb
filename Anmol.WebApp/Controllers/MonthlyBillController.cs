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
    public class MonthlyBillController : Controller
    {
        // GET: MonthlyBill
        public ActionResult Index()
        {
            ViewBag.CustomerList = DataSourceHelper.GetCustomerList();
            return View();
        }

        public async Task<ActionResult> GetMonthlyBillList(string CustName, string BillMonth)
        {
            if (BillMonth != "")
                BillMonth += "-01";
            var result = new ApiResponse<MonthlyBillModel>();
            var uri = "GetMonthlyBillList?CustName=" + CustName + "&BillMonth=" + BillMonth;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.Index, ControllerHelper.Cow);
            }
        }
    }
}