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
    public class PermenentOrderController : Controller
    {
        // GET: PermenentOrder
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetOrderList(string name, string DeliveryTime)
        {
        
            var result = new ApiResponse<PermanentOrderModel>();
            var uri = "GetOrderList?name=" + name + "&DeliveryTime=" + DeliveryTime;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.Index, ControllerHelper.PermenentOrder);
            }
        }

        public async Task<ActionResult> GetMilkOrderById(int Id)
        {
            ViewBag.CustomerList = DataSourceHelper.GetCustomerList();
            var model = new PermanentOrderModel();
            if (Id > 0)
            {
                var result = new ApiPostResponse<PermanentOrderModel>();
                var uri = "GetMilkOrderById?Id=" + Id;
                result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
                if (result.Data != null)
                {
                    model = result.Data;
                }
                else
                {
                    TempData["Error"] = "Somthing went wrong.";
                    return View(ViewHelper.PermanentOrder);
                }
            }
            else
            {
                model.Id = 0;
            }
            return View(ViewHelper.AddEditPermanentOrder, model);
        }

        [HttpPost]
        public async Task<ActionResult> SaveMilkOrder(PermanentOrderModel model)
        {
            try
            {
                model.LoggedinUserName = SessionHelper.LoggedInUserName;
                var response = new ApiResponse<PermanentOrderModel>();
                var url = "SaveMilkOrder";
                response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<PermanentOrderModel>, PermanentOrderModel>(model, url, SessionHelper.AuthToken);
                if (response.Success == true)
                {

                    if (model.Id > 0)
                    {
                        await DataSourceHelper.SaveAuditTrail("Edit Order", "Edit");
                    }
                    else
                    {
                        await DataSourceHelper.SaveAuditTrail("Add new Order", "Add");
                    }
                    TempData["Message"] = model.Id > 0 ? "Milk Order Updated Successfully" : "Milk Order Added Successfully";
                }
                else
                {
                    TempData["Error"] = response.Message;
                }
                return RedirectToAction("Index", ControllerHelper.PermenentOrder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<ActionResult> DeleteMilkOrder(int Id = 0)
        {
            PermanentOrderModel model = new PermanentOrderModel();
            model.Id = Id;
            var response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<PermanentOrderModel>, PermanentOrderModel>(model, "DeleteMilkOrder", SessionHelper.AuthToken);
            await DataSourceHelper.SaveAuditTrail("Delete Milk Order", "Delete");
            return Json(new { Flag = response.Success }, JsonRequestBehavior.AllowGet);
        }
    }
}