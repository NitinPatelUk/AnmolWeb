using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.Service;

namespace _Anmol.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class CustomerDailyDeliveryController : ApiController
    {
        private readonly CustomerDailyDeliveryService objService;        

        public CustomerDailyDeliveryController()
        {
            objService = new CustomerDailyDeliveryService();            
        }

        [HttpPost]
        [Route("CustomerDailyDelivery")]
        public BaseApiResponse CustomerDailyDelivery()
        {
            var result = objService.CustomerDailyDelivery();
            return result;
        }
    }
}
