using _Anmol.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public JsonResult GetDeliveryHistoryList()
        {
            //Creating List      
            List<CustomerDeliveryHistoryModel> ObjEmp = new List<CustomerDeliveryHistoryModel>()
            {
                new CustomerDeliveryHistoryModel
                {
                    SrNO = 1, DeliveryDate = "05/05/2021", DeliveryMilk = 8
                },
                new CustomerDeliveryHistoryModel
                {
                    SrNO = 2,  DeliveryDate ="06/05/2021", DeliveryMilk = 8
                },
                 new CustomerDeliveryHistoryModel
                {
                    SrNO = 3, DeliveryDate = "05/05/2021", DeliveryMilk = 5
                },
                 new CustomerDeliveryHistoryModel
                {
                    SrNO = 4, DeliveryDate = "06/05/2021", DeliveryMilk = 8
                },
                 new CustomerDeliveryHistoryModel
                {
                    SrNO = 5, DeliveryDate = "05/05/2021", DeliveryMilk = 7
                }
            };
            return Json(ObjEmp, JsonRequestBehavior.AllowGet);
        }
    }
}