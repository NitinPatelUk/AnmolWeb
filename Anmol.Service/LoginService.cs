using _Anmol.Common;
using _Anmol.Data.Repository;
using _Anmol.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Service
{
    public class LoginService
    {
        public ApiResponse<LoginModel> LoginUser(LoginModel model)
        {
            ApiResponse<LoginModel> response = new ApiResponse<LoginModel>();
            try
            {
                GenericRepository<LoginModel> objGenericRepository = new GenericRepository<LoginModel>();
                var result = objGenericRepository.QuerySQL<LoginModel>("SP_UserLogin", Utility.GetSQLParam("EmailAddress", SqlDbType.VarChar, model.EmailAddress),
                    Utility.GetSQLParam("Password", SqlDbType.VarChar, (object)model.Password ?? DBNull.Value));

                response.Data = result.ToList();
                if (response.Data != null && response.Data.Count > 0)
                {
                    response.Success = true;
                    response.Message.Add("Success");
                }
                else
                {
                    response.Success = false;
                    response.Message.Add("You have entered an invalid username or password. please try again");
                }

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message.Add(ex.Message);
                response.Success = false;
            }
            return response;
        }
    }
}
