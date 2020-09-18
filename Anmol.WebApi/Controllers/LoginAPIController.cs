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
    public class LoginAPIController : ApiController
    {
        private readonly LoginService _loginService;

        public LoginAPIController()
        {
            _loginService = new LoginService();

        }
        [Route("GetToken")]
        public ApiPostResponse<string> GetToken(string EmailAddress)
        {
            ApiPostResponse<string> response = new ApiPostResponse<string>();
            var userToken = JwtAuthManager.GenerateJWTToken(EmailAddress);
            response.Success = true;
            response.Data = userToken;
            return response;
        }

        [Route("LoginUser")]
        public ApiResponse<LoginModel> LoginUser(LoginModel model)
        {
            return _loginService.LoginUser(model);
        }
    }
}
