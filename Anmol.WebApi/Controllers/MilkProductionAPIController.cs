using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.Service;
using System;
using System.Web.Http;

namespace _Anmol.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class MilkProductionAPIController : ApiController
    {
        private readonly MilkProductionService _milkproductionService;

        public MilkProductionAPIController()
        {
            _milkproductionService = new MilkProductionService();
        }

        [Route("GetMilkProductionById")]
        public ApiPostResponse<MilkProductionModel> GetMilkProductionById(int MilkProductionId)
        {
            return _milkproductionService.GetMilkProductionById(MilkProductionId);
        }

        [HttpPost]
        [Route("SaveMilkProduction")]
        public ApiResponse<MilkProductionModel> SaveMilkProduction(MilkProductionModel model)
        {
            return _milkproductionService.SaveMilkProduction(model);
        }

        [HttpPost]
        [Route("DeleteMilkProduction")]
        public BaseApiResponse DeleteMilkProduction(MilkProductionModel model)
        {
            return _milkproductionService.DeleteMilkProduction(model);
        }

        [Route("GetMilkProductionList")]
        public ApiResponse<MilkProductionModel> GetMilkProductionList(string name, int? CowId,DateTime? MilkingDate, string MilkingTime)
        {
            return _milkproductionService.GetMilkProductionList(name, CowId, MilkingDate, MilkingTime);
        }

        [Route ("GetMilkableCowList")]
        public ApiResponse<MilkProductionModel> GetMilkableCowList()
        {
            return _milkproductionService.GetMilkableCowList();
        }
        [Route("SaveMilkProductionByID")]
        public ApiResponse<MilkProductionModel> SaveMilkProductionByID(MilkProductionModel model)
        {
            return _milkproductionService.SaveMilkProductionByID(model);
        }
    }
}