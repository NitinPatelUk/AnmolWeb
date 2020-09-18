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
    [JwtAuthentication]
    [RoutePrefix("api")]
    public class CommonAPIController : ApiController
    {
        private readonly CommonService _commonService;
        public CommonAPIController()
        {
            _commonService = new CommonService();
        }

        [Route("SaveAuditTrail")]
        public BaseApiResponse SaveAuditTrail(string Action, int UserId, string ActionType)
        {
            return _commonService.SaveAuditTrail(Action, UserId, ActionType);
        }

        [Route("GetUserRoleList")]
        public ApiResponse<UserRoleModel> GetUserRoleList()
        {
            return _commonService.GetUserRoleList();
        }

      
    }
}
