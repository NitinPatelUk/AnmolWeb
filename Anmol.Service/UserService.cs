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
    public class UserService
    {
        public ApiResponse<UserModel> GetUserList(string name, int? roleId, string email, string mobile)
        {
            ApiResponse<UserModel> response = new ApiResponse<UserModel>();
            try
            {
                GenericRepository<UserModel> objGenericRepository = new GenericRepository<UserModel>();
                var result = objGenericRepository.QuerySQL<UserModel>("SP_GetUserList", Utility.GetSQLParam("Name", SqlDbType.VarChar, (object)name ?? DBNull.Value)
                                                                                      , Utility.GetSQLParam("RoleId", SqlDbType.Int, (object)roleId ?? DBNull.Value)
                                                                                      , Utility.GetSQLParam("Email", SqlDbType.VarChar, (object)email ?? DBNull.Value)
                                                                                      , Utility.GetSQLParam("Mobile", SqlDbType.VarChar, (object)mobile ?? DBNull.Value));
                response.Data = result.ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message.Add(ex.Message);
                response.Success = false;
            }
            return response;
        }

        public ApiPostResponse<UserModel> GetUserById(int userId)
        {
            ApiPostResponse<UserModel> response = new ApiPostResponse<UserModel>();
            try
            {
                GenericRepository<UserModel> objGenericRepository = new GenericRepository<UserModel>();
                var result = objGenericRepository.QuerySQL<UserModel>("SP_GetUserById",
                    Utility.GetSQLParam("UserId", SqlDbType.Int, (object)userId ?? DBNull.Value));
                response.Data = result.FirstOrDefault();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message.Add(ex.Message);
                response.Success = false;
            }
            return response;
        }
        public ApiResponse<UserModel> SaveUser(UserModel model)
        {
            ApiResponse<UserModel> response = new ApiResponse<UserModel>();
            try
            {
                GenericRepository<UserModel> objGenericRepository = new GenericRepository<UserModel>();

                var result = objGenericRepository.QuerySQL<UserModel>("SP_AddEditUser",
                    Utility.GetSQLParam("UserId", SqlDbType.Int, (object)model.UserId ?? DBNull.Value),
                    Utility.GetSQLParam("FullName", SqlDbType.VarChar, (object)model.FullName ?? DBNull.Value),
                    Utility.GetSQLParam("UserRoleId", SqlDbType.Int, (object)model.UserRoleId ?? DBNull.Value),
                    Utility.GetSQLParam("EmailAddress", SqlDbType.VarChar, (object)model.EmailAddress ?? DBNull.Value),
                    Utility.GetSQLParam("Password", SqlDbType.VarChar, (object)model.Password ?? DBNull.Value),
                    Utility.GetSQLParam("Mobile", SqlDbType.VarChar, (object)model.Mobile ?? DBNull.Value),
                    Utility.GetSQLParam("JoiningDate", SqlDbType.DateTime, (object)model.JoiningDate ?? DBNull.Value),
                    Utility.GetSQLParam("LeavingDate", SqlDbType.DateTime, (object)model.LeavingDate ?? DBNull.Value),
                    Utility.GetSQLParam("ReportingManagerId", SqlDbType.Int, (object)model.ReportingManagerId ?? DBNull.Value),
                    Utility.GetSQLParam("LoggedinUserName", SqlDbType.VarChar, (object)model.LoggedinUserName ?? DBNull.Value)
                   );
                response.Data = result.ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message.Add(ex.Message);
                response.Success = false;
            }
            return response;
        }

        public BaseApiResponse DeleteUser(UserModel model)
        {
            BaseApiResponse response = new BaseApiResponse();
            try
            {
                GenericRepository<UserModel> objGenericRepository = new GenericRepository<UserModel>();
                var result = objGenericRepository.ExecuteSQL<int>("SP_DeleteUser",
                    Utility.GetSQLParam("UserId", SqlDbType.Int, (object)model.UserId ?? DBNull.Value));
                if (result.FirstOrDefault() > 0)
                {
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(ex.Message);
                response.Success = false;
            }
            return response;
        }
    }
}
