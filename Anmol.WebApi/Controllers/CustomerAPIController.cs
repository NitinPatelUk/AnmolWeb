using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _Anmol.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class CustomerAPIController : ApiController
    {
        private readonly CustomerService _customerService;

        public CustomerAPIController()
        {
            _customerService = new CustomerService();
        }

        [Route("GetCustomerList")]
        public ApiResponse<CustomerModel> GetCustomerList(string name, int? Zipcode, string ContactNumber, string CustAddress)
        {
            return _customerService.GetCustomerList(name, Zipcode, ContactNumber, CustAddress);
        }

        [Route("GetCustomerById")]
        public ApiPostResponse<CustomerModel> GetCustomerById(int custId)
        {
            return _customerService.GetCustomerById(custId);
        }

        [HttpPost]
        [Route("SaveCustomer")]
        public ApiResponse<CustomerModel> SaveCustomer(CustomerModel model)
        {
            return _customerService.SaveCustomer(model);
        }

        [HttpPost]
        [Route("DeleteCustomer")]
        public BaseApiResponse DeleteCustomer(CustomerModel model)
        {
            return _customerService.DeleteCustomer(model);
        }

        [Route("GetCustomerDetails")]
        public ApiPostResponse<CustomerModel> GetCustomerDetails(int custId)
        {
            return _customerService.GetCustomerDetails(custId);
        }
    }
}