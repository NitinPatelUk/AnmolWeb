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
    public class CustomerTemporaryOrderAPIController : ApiController
    {
        private readonly CustomerTemporaryOrderService _customerTemporaryOrderService;

        public CustomerTemporaryOrderAPIController()
        {
            _customerTemporaryOrderService = new CustomerTemporaryOrderService();
        }

        [Route("GetCustomerTemporaryOrderById")]
        public ApiPostResponse<CustomerTemporaryOrderModel> GetCustomerTemporaryOrderById(int CustTempOrdId)
        {
            return _customerTemporaryOrderService.GetCustomerTemporaryOrderById(CustTempOrdId);
        }

        [HttpPost]
        [Route("SaveCustomerTemporaryOrder")]
        public ApiResponse<CustomerTemporaryOrderModel> SaveCustomerTemporaryOrder(CustomerTemporaryOrderModel model)
        {
            return _customerTemporaryOrderService.SaveCustomerTemporaryOrder(model);
        }

        [HttpPost]
        [Route("DeleteCustomerTemporaryOrder")]
        public BaseApiResponse DeleteCustomerTemporaryOrder(CustomerTemporaryOrderModel model)
        {
            return _customerTemporaryOrderService.DeleteCustomerTemporaryOrder(model);
        }

        [Route("GetCustomerTemporaryOrderList")]
        public ApiResponse<CustomerTemporaryOrderModel> GetCustomerTemporaryOrderList(string CustName, string DeliveryTime, string StartDate, string EndDate)
        {
            return _customerTemporaryOrderService.GetCustomerTemporaryOrderList(CustName, DeliveryTime, StartDate, EndDate);
        }
    }
}
