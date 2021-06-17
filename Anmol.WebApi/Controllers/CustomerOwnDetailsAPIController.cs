using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _Anmol.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class CustomerOwnDetailsAPIController : ApiController
    {
        private readonly CustomerOwnDetailsService _CustomerOwnDetails;

        public CustomerOwnDetailsAPIController()
        {
            _CustomerOwnDetails = new CustomerOwnDetailsService();
        }

        [Route("GetCustomerOwnDetails")]
        public ApiResponse<CustomerOwnDetailsModel> GetCustomerOwnDetails(int? CustID)
        {
            return _CustomerOwnDetails.GetCustomerOwnDetails(CustID);
        }
    }
}
