using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.WebApp.Common;
using System;

using System.Threading.Tasks;
using System.Web.Mvc;

namespace _Anmol.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetCustomerList(string name, int? Zipcode, string ContactNumber, string CustAddress)
        {
            var result = new ApiResponse<CustomerModel>();
            var uri = "GetCustomerList?name=" + name + "&zipcode=" + Zipcode + "&contactnumber" + ContactNumber + "&custaddress" + CustAddress;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.Index, ControllerHelper.Customer);
            }
        }

        public async Task<ActionResult> GetCustomerById(int CustId)
        {
            var model = new CustomerModel();
            if (CustId > 0)
            {
                var result = new ApiPostResponse<CustomerModel>();
                var uri = "GetCustomerById?custId=" + CustId;
                result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
                if (result.Data != null)
                {
                    model = result.Data;
                }
                else
                {
                    TempData["Error"] = "Somthing went wrong.";
                    return View(ViewHelper.Customer);
                }
            }
            else
            {
                model.CustID = 0;
            }
            return View(ViewHelper.AddEditCustomer, model);
        }

        [HttpPost]
        public async Task<ActionResult> SaveCustomer(CustomerModel model)
        {
            try
            {
                model.LoggedinUserName = SessionHelper.LoggedInUserName;
                var response = new ApiResponse<CustomerModel>();
                var url = "SaveCustomer";
                response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<CustomerModel>, CustomerModel>(model, url, SessionHelper.AuthToken);
                if (response.Success == true)
                {
                    if (model.CustID > 0)
                    {
                        await DataSourceHelper.SaveAuditTrail("Edit Customer", "Edit");
                    }
                    else
                    {
                        await DataSourceHelper.SaveAuditTrail("Add new Customer", "Add");
                    }
                    TempData["Message"] = model.CustID > 0 ? "Customer Updated Successfully" : "Customer Added Successfully";
                }
                else
                {
                    TempData["Error"] = response.Message;
                }
                return RedirectToAction("Index", ControllerHelper.Customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<ActionResult> DeleteCustomer(int CustId = 0)
        {
            CustomerModel model = new CustomerModel();
            model.CustID = CustId;
            var response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<CustomerModel>, CustomerModel>(model, "DeleteCustomer", SessionHelper.AuthToken);
            await DataSourceHelper.SaveAuditTrail("Delete Customer", "Delete");
            return Json(new { Flag = response.Success }, JsonRequestBehavior.AllowGet);
        }
    }
}