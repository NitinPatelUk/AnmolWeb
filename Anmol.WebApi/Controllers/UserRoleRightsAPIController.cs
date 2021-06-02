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
    public class UserRoleRightsAPIController : ApiController
    {
        private readonly UserRoleRightsService _userRoleRightsService;
        public UserRoleRightsAPIController()
        {
            _userRoleRightsService = new UserRoleRightsService();
        }

        [Route("GetUserRoleDetailList")]
        public ApiResponse<UserRoleRightsModel> GetUserRoleDetailList()
        {
            return _userRoleRightsService.GetUserRoleDetailList();
        }

        [Route("GetUserRoleRightsById")]
        public ApiResponse<UserRoleRightsList> GetUserRoleRightsById(int UserRoleId)
        {
            return _userRoleRightsService.GetUserRoleRightsById(UserRoleId);
        }

        [HttpPost]
        [Route("SaveUserRoleRights")]
        public BaseApiResponse SaveUserRoleRights(UserRoleRightsModel objModel)
        {
            return _userRoleRightsService.SaveUserRoleRights(objModel);
        }

        [Route("GetUserAccessRights")]
        public ApiResponse<UserRightsModel> GetUserAccessRights(int UserRoleId)
        {
            return _userRoleRightsService.GetUserAccessRights(UserRoleId);
        }

        [Route("GetUserMenu")]
        public ApiPostResponse<string> GetUserMenu(int UserRoleId)
        {
            return _userRoleRightsService.GetUserMenu(UserRoleId);
        }

    }
}
