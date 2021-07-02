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

        //[HttpGet]
        //public JsonResult GetMilkOrerDetail()
        //{
        //    //Creating List      
        //    List<CustomerMilkOrderModel> ObjEmp = new List<CustomerMilkOrderModel>()
        //    {
        //        new CustomerMilkOrderModel
        //        {
        //            SrNO = 1, FromDate = "05/05/2021", ToDate = "08/05/2021", TemporaryOrder = 8
        //        },
        //        new CustomerMilkOrderModel
        //        {
        //            SrNO = 2, FromDate = "05/05/2021", ToDate = "08/05/2021", TemporaryOrder = 8
        //        },
        //         new CustomerMilkOrderModel
        //        {
        //            SrNO = 3,FromDate = "05/05/2021", ToDate = "08/05/2021", TemporaryOrder = 8
        //        },
        //         new CustomerMilkOrderModel
        //        {
        //            SrNO = 4, FromDate = "05/05/2021", ToDate = "08/05/2021", TemporaryOrder = 8
        //        },
        //         new CustomerMilkOrderModel
        //        {
        //            SrNO = 5,FromDate = "05/05/2021", ToDate = "08/05/2021", TemporaryOrder = 8
        //        }
        //    };
        //    return Json(ObjEmp, JsonRequestBehavior.AllowGet);
        //}

        public async Task<ActionResult> GetCustTempOrderByID()
        {
            ViewBag.CustomerList = DataSourceHelper.GetCustomerList();
            int CustID = SessionHelper.UserId;
            var model = new CustomerTemporaryOrderModel();
            if (CustID > 0)
            {
                var result = new ApiResponse<CustomerTemporaryOrderModel>();
                var uri = "GetCustTempOrderByID?CustID=" + CustID;
                result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
                if (result.Data != null)
                {
                    //model = result.Data;
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    TempData["Error"] = "Somthing went wrong.";
                    return View(ViewHelper.AddEditCustomerTemporaryOrder);
                }
            }
            else
            {
                model.CustTempOrdId = 0;
                model.StartDate = DateTime.Today;
                model.EndDate = DateTime.Today;
            }
            return View(ViewHelper.AddEditCustomerTemporaryOrder, model);
        }
    }
}