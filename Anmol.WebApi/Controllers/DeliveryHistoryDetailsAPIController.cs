using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.Service;
using _Anmol.WebApi.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _Anmol.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class DeliveryHistoryDetailsAPIController : ApiController
    {
        private readonly DeliveryHistoryDetailsService _deliveryHistoryDetailsService;

        public DeliveryHistoryDetailsAPIController()
        {
            _deliveryHistoryDetailsService = new DeliveryHistoryDetailsService();
        }

        [Route("GetCustomerMilkOrderHistory")]
        public ApiResponse<CustomerMilkOrderModel> GetCustomerMilkOrderHistory(int CustId, string FromDate, string ToDate)
        {
            return _deliveryHistoryDetailsService.GetCustomerMilkOrderHistory(CustId, FromDate, ToDate);
        }               
    }
}