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
    public class PermenentOrderAPIController : ApiController
    {
        private readonly PermenentOrderService _permenentOrderService;

        public PermenentOrderAPIController()
        {
            _permenentOrderService = new PermenentOrderService();
        }

        [Route("GetMilkOrderById")]
        public ApiPostResponse<PermanentOrderModel> GetMilkOrderById(int Id)
        {
            return _permenentOrderService.GetMilkOrderById(Id);
        }

        [HttpPost]
        [Route("SaveMilkOrder")]
        public ApiResponse<PermanentOrderModel> SaveMilkOrder(PermanentOrderModel model)
        {
            return _permenentOrderService.SaveMilkOrder(model);
        }

        [HttpPost]
        [Route("DeleteMilkOrder")]
        public BaseApiResponse DeleteMilkOrder(PermanentOrderModel model)
        {
            return _permenentOrderService.DeleteMilkOrder(model);
        }

        [Route("GetOrderList")]
        public ApiResponse<PermanentOrderModel> GetOrderList(string Name,string DeliveryTime)
        {
            return _permenentOrderService.GetOrderList(Name, DeliveryTime);
        }
    }
}
