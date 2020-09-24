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
    public class CowAPIController : ApiController
    {
        private readonly CowService _cowService;

        public CowAPIController()
        {
            _cowService = new CowService();
        }

        [Route("GetAllCowList")]
        public ApiResponse<CowModel> GetAllCowList(string name, int? cowId)
        {
            return _cowService.GetAllCowList(name, cowId);
        }

        [Route("GetCowById")]
        public ApiPostResponse<CowModel> GetCowById(int cowId)
        {
            return _cowService.GetCowById(cowId);
        }

        [HttpPost]
        [Route("SaveCow")]
        public ApiResponse<CowModel> SaveCow(CowModel model)
        {
            return _cowService.SaveCow(model);
        }
        
        [HttpPost]
        [Route("DeleteCow")]
        public BaseApiResponse DeleteCow(CowModel model)
        {
            return _cowService.DeleteCow(model);
        }

        [Route("GetCowList")]
        public ApiResponse<CowModel> GetCowList()
        {
            return _cowService.GetCowList();
        }

        [Route("GetBullList")]
        public ApiResponse<CowModel> GetBullList()
        {
            return _cowService.GetBullList();
        }
    }
}