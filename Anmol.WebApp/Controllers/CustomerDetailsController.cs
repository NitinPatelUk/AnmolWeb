using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using _Anmol.WebApp.Common;
using _Anmol.Common;
using _Anmol.Entity;

namespace _Anmol.WebApp.Controllers
{
    public class CustomerDetailsController : Controller
    {
        // GET: CustomerDetails
        public async Task<ActionResult> CustomerOwnDetails()
        {
            var model = new CustomerModel();
            var result = new ApiPostResponse<CustomerModel>();
            var uri = "GetCustomerDetails?custId=" + SessionHelper.UserId;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            model = result.Data;
            return View(model);
        }

    }
}