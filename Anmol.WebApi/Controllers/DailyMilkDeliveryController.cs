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
    public class DailyMilkDeliveryController : ApiController
    {
        private readonly CustomerDailyDeliveryService _CustomerDailyDeliveryService;

        public DailyMilkDeliveryController()
        {
            _CustomerDailyDeliveryService = new CustomerDailyDeliveryService();
        }

        [Route("GetDailyDeliveryList")]
        public ApiResponse<DailyMilkDelivery> GetDailyDeliveryList(string CustName,DateTime FromDate,DateTime ToDate)
        {
            return _CustomerDailyDeliveryService.GetDailyDeliveryList(CustName,FromDate, ToDate);
        }
    }
}
