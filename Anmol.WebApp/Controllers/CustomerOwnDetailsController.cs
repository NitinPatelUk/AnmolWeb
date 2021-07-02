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
    public class CustomerOwnDetailsController : Controller
    {
        // GET: CustomerDetails
        public async Task<ActionResult> Index()
        {
            int CustID = SessionHelper.UserId;
            var result = new ApiResponse<CustomerOwnDetailsModel>();
            var uri = "GetCustomerOwnDetails?CustID=" + CustID;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.GetCustomerOwnDetails, ControllerHelper.CustomerOwnDetails);
            }

        }

        public async Task<ActionResult> GetCustomerOwnDetails()
        {
            return View();
        }

        public async Task<ActionResult> GetCustomerOwnDetailsById()
            {       
                    var model = new CustomerOwnDetailsModel();
            var CustID = SessionHelper.UserId;
            if (CustID > 0)
            {
                var result = new ApiPostResponse<CustomerOwnDetailsModel>();
                var uri = "GetCustomerOwnDetailsById?CustID=" + CustID;
                result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
                if (result.Data != null)
                {
                    model = result.Data;
                }
                else
                {
                    TempData["Error"] = "Somthing went wrong.";
                    return View(ViewHelper.GetCustomerOwnDetails);
                }
            }
            else
            {
                model.CustID = 0;
            }
            return View(ViewHelper.EditCustomerOwnDetails, model);
        }


        [HttpPost]
        public async Task<ActionResult> SaveCustomerOwnDetails(CustomerOwnDetailsModel model)
        {
            try
            {
                var response = new ApiResponse<CustomerOwnDetailsModel>();
                var url = "SaveCustomerOwnDetails";
                response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<CustomerOwnDetailsModel>, CustomerOwnDetailsModel>(model, url, SessionHelper.AuthToken);
                if (response.Success == true)
                {
                    if (model.CustID > 0)
                    {
                        await DataSourceHelper.SaveAuditTrail("Edit Customer", "Edit");
                    }
                    //else
                    //{
                    //    await DataSourceHelper.SaveAuditTrail("Add new Customer", "Add");
                    //}
                    TempData["Message"] = model.CustID > 0 ? "Customer Updated Successfully" : "Customer Added Successfully";
                }
                else
                {
                    TempData["Error"] = response.Message;
                }
                return RedirectToAction(ActionHelper.GetCustomerOwnDetails, ControllerHelper.CustomerOwnDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

    }
}