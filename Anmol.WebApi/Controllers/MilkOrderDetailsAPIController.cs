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
    public class MilkOrderDetailsAPIController : ApiController
    {
        private readonly MilkOrderDetailsService _milkOrderDetailsService;

        public MilkOrderDetailsAPIController()
        {
            _milkOrderDetailsService = new MilkOrderDetailsService();
        }

        [Route("GetMilkOrderList")]
        public ApiResponse<CustomerMilkOrderModel> GetMilkOrderList(int CustId)
        {
            return _milkOrderDetailsService.GetMilkOrderList(CustId);
        }

        [HttpPost]
        [Route("SaveCustomerTemporaryMilkOrder")]
        public ApiResponse<CustomerMilkOrderModel> SaveCustomerTemporaryMilkOrder(CustomerMilkOrderModel model)
        {
            return _milkOrderDetailsService.SaveCustomerTemporaryMilkOrder(model);
        }                

        //[HttpPost]
        //[Route("DeleteCow")]
        //public BaseApiResponse DeleteCow(CowModel model)
        //{
        //    return _cowService.DeleteCow(model);
        //}        
    }
}