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
    public class UserAPIController : ApiController
    {
        private readonly UserService _userService;

        public UserAPIController()
        {
            _userService = new UserService();
        }

        [Route("GetUserList")]
        public ApiResponse<UserModel> GetUserList(string name, int? roleId, string email, string mobile)
        {
            return _userService.GetUserList(name, roleId, email, mobile);
        }

        [Route("GetUserById")]
        public ApiPostResponse<UserModel> GetUserById(int userId)
        {
            return _userService.GetUserById(userId);
        }

        [HttpPost]
        [Route("SaveUser")]
        public ApiResponse<UserModel> SaveUser(UserModel model)
        {
            return _userService.SaveUser(model);
        }

        [HttpPost]
        [Route("DeleteUser")]
        public BaseApiResponse DeleteUser(UserModel model)
        {
            return _userService.DeleteUser(model);
        }
    }
}
