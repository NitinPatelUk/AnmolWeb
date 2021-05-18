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
    public class CustomerTemporaryOrderController : Controller
    {
        // GET: CustomerTemporaryOrder
        public ActionResult Index()
        {
            ViewBag.CustomerList = DataSourceHelper.GetCustomerList();
            return View();
        }


        public async Task<ActionResult> GetCustomerTemporaryOrderList(string CustName, string DeliveryTime, string StartDate, string EndDate)
        {
            var result = new ApiResponse<CustomerTemporaryOrderModel>();
            var uri = "GetCustomerTemporaryOrderList?CustName=" + CustName + "&DeliveryTime=" + DeliveryTime + "&StartDate=" + StartDate + "&EndDate=" + EndDate;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.Index, ControllerHelper.CustomerTemporaryOrder);
            }
        }


        public async Task<ActionResult> GetCustomerTemporaryOrderById(int CustTempOrdId)
        {
            ViewBag.CustomerList = DataSourceHelper.GetCustomerList();
            
            var model = new CustomerTemporaryOrderModel();
            if (CustTempOrdId > 0)
            {
                var result = new ApiPostResponse<CustomerTemporaryOrderModel>();
                var uri = "GetCustomerTemporaryOrderById?CustTempOrdId=" + CustTempOrdId;
                result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
                if (result.Data != null)
                {
                    model = result.Data;
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

        [HttpPost]
        public async Task<ActionResult> SaveCustomerTemporaryOrder(CustomerTemporaryOrderModel model)
        {
            try
            {
                model.LoggedinUserName = SessionHelper.LoggedInUserName;

                var response = new ApiResponse<CustomerTemporaryOrderModel>();
                var url = "SaveCustomerTemporaryOrder";
                response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<CustomerTemporaryOrderModel>, CustomerTemporaryOrderModel>(model, url, SessionHelper.AuthToken);
                if (response.Success == true)
                {

                    if (model.CustTempOrdId > 0)
                    {
                        await DataSourceHelper.SaveAuditTrail("Edit Customer Temporary Order", "Edit");
                    }
                    else
                    {
                        await DataSourceHelper.SaveAuditTrail("Add new Customer Temporary Order", "Add");
                    }
                    TempData["Message"] = model.CustTempOrdId > 0 ? "Customer Temporary Order Updated Successfully" : "Customer Temporary Order Added Successfully";
                }
                else
                {
                    TempData["Error"] = response.Message;
                }
                return RedirectToAction(ActionHelper.Index, ControllerHelper.CustomerTemporaryOrder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<ActionResult> DeleteCustomerTemporaryOrder(int CustTempOrdId = 0)
        {
            CustomerTemporaryOrderModel model = new CustomerTemporaryOrderModel();
            model.CustTempOrdId = CustTempOrdId;
            var response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<CustomerTemporaryOrderModel>, CustomerTemporaryOrderModel>(model, "DeleteCustomerTemporaryOrder", SessionHelper.AuthToken);
            await DataSourceHelper.SaveAuditTrail("Delete Customer Temporary Order", "Delete");
            return Json(new { Flag = response.Success }, JsonRequestBehavior.AllowGet);
        }

    }
}