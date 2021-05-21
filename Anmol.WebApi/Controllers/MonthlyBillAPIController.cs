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
    public class MonthlyBillAPIController : ApiController
    {
        private readonly MonthlyBillService _monthlyBillService;

        public MonthlyBillAPIController()
        {
            _monthlyBillService = new MonthlyBillService();
        }


        [Route("GetMonthlyBillList")]
        public ApiResponse<MonthlyBillModel> GetMonthlyBillList(string CustName, string BillMonth)
        {
            return _monthlyBillService.GetMonthlyBillList(CustName,BillMonth);
        }
    }
}
