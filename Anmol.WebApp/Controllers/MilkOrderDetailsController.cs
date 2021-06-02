using _Anmol.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public JsonResult GetMilkOrerDetail()
        {
            //Creating List      
            List<CustomerMilkOrderModel> ObjEmp = new List<CustomerMilkOrderModel>()
            {
                new CustomerMilkOrderModel
                {
                    SrNO = 1, FromDate = "05/05/2021", ToDate = "08/05/2021", TemporaryOrder = 8
                },
                new CustomerMilkOrderModel
                {
                    SrNO = 2, FromDate = "05/05/2021", ToDate = "08/05/2021", TemporaryOrder = 8
                },
                 new CustomerMilkOrderModel
                {
                    SrNO = 3,FromDate = "05/05/2021", ToDate = "08/05/2021", TemporaryOrder = 8
                },
                 new CustomerMilkOrderModel
                {
                    SrNO = 4, FromDate = "05/05/2021", ToDate = "08/05/2021", TemporaryOrder = 8
                },
                 new CustomerMilkOrderModel
                {
                    SrNO = 5,FromDate = "05/05/2021", ToDate = "08/05/2021", TemporaryOrder = 8
                }
            };
            return Json(ObjEmp, JsonRequestBehavior.AllowGet);
        }

    }
}