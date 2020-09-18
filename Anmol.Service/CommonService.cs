using _Anmol.Common;
using _Anmol.Data.Repository;
using _Anmol.Entity;
using System;
using System.Data;
using System.Linq;



namespace _Anmol.Service
{
    public class CommonService
    {
        public BaseApiResponse SaveAuditTrail(string Action, int UserId, string ActionType)
        {
            BaseApiResponse response = new BaseApiResponse();
            try
            {
                GenericRepository<LoginModel> objGenericRepository = new GenericRepository<LoginModel>();
                var result = objGenericRepository.ExecuteSQL<int>("SP_AuditTrail_Insert", Utility.GetSQLParam("Action", SqlDbType.VarChar, (object)Action ?? DBNull.Value)
                                                                                        , Utility.GetSQLParam("ActionType", SqlDbType.VarChar, (object)ActionType ?? DBNull.Value)
                                                                                        , Utility.GetSQLParam("UserId", SqlDbType.Int, (object)UserId ?? DBNull.Value));

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

        public ApiResponse<UserRoleModel> GetUserRoleList()
        {
            ApiResponse<UserRoleModel> response = new ApiResponse<UserRoleModel>();
            try
            {
                GenericRepository<UserRoleModel> objGenericRepository = new GenericRepository<UserRoleModel>();
                var result = objGenericRepository.QuerySQL<UserRoleModel>("SP_GetUserRoleList");
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

    }
}
