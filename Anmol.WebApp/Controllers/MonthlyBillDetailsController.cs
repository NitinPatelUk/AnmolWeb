using _Anmol.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _Anmol.WebApp.Controllers
{
    public class MonthlyBillDetailsController : Controller
    {
        // GET: MonthlyBillDetails
        public ActionResult GetMonthlyBillDetails()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetMonthlyBill()
        {
            //Creating List      
            List<CustomerMonthlyBillModel> ObjEmp = new List<CustomerMonthlyBillModel>()
            {
                new CustomerMonthlyBillModel
                {
                    SrNO = 1, Month = "January", TotalQty = 50, Amount = 4000
                },
                new CustomerMonthlyBillModel
                {
                    SrNO = 2, Month = "Febuary", TotalQty = 60, Amount = 5000
                },
                 new CustomerMonthlyBillModel
                {
                    SrNO = 3, Month = "March", TotalQty = 40, Amount = 3000
                },
                 new CustomerMonthlyBillModel
                {
                    SrNO = 4, Month = "April", TotalQty = 60, Amount = 5000
                },
                 new CustomerMonthlyBillModel
                {
                    SrNO = 5, Month = "May", TotalQty = 40, Amount = 3000
                }
            };
            return Json(ObjEmp, JsonRequestBehavior.AllowGet);
        }
    }
}