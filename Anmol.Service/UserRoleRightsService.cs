using _Anmol.Common;
using _Anmol.Data.Repository;
using _Anmol.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRoleRightsModel = _Anmol.Entity.UserRoleRightsModel;

namespace _Anmol.Service
{
    public class UserRoleRightsService
    {
        public ApiResponse<UserRoleRightsModel> GetUserRoleDetailList()
        {
            ApiResponse<UserRoleRightsModel> response = new ApiResponse<UserRoleRightsModel>();
            try
            {
                GenericRepository<UserRoleRightsModel> objGenericRepository = new GenericRepository<UserRoleRightsModel>();
                var result = objGenericRepository.QuerySQL<UserRoleRightsModel>("SP_GetUserRoleList");
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

        public ApiResponse<UserRoleRightsList> GetUserRoleRightsById(int UserRoleId)
        {
            ApiResponse<UserRoleRightsList> response = new ApiResponse<UserRoleRightsList>();
            try
            {
                GenericRepository<UserRoleRightsList> objGenericRepository = new GenericRepository<UserRoleRightsList>();
                var result = objGenericRepository.QuerySQL<UserRoleRightsList>("SP_GetUserRoleRights",
                    Utility.GetSQLParam("UserRoleId", SqlDbType.Int, (object)UserRoleId ?? DBNull.Value));
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

        public BaseApiResponse SaveUserRoleRights(UserRoleRightsModel objModel)
        {
            BaseApiResponse response = new BaseApiResponse();
            try
            {
                DataTable dtTable = new DataTable("UserRoleRights");
                dtTable.Columns.Add("RoleId");
                dtTable.Columns.Add("MenuId");
                dtTable.Columns.Add("RightId");

                foreach (var item in objModel.UserRoleRights)
                {
                    DataRow dtRow;
                    if (item.ViewRight)
                    {
                        dtRow = dtTable.NewRow();
                        dtRow["RoleId"] = objModel.UserRoleId;
                        dtRow["MenuId"] = item.MenuId;
                        dtRow["RightId"] = Enums.AccessRight.View.GetHashCode();
                        dtTable.Rows.Add(dtRow);
                    }
                    if (item.CreateRight)
                    {
                        dtRow = dtTable.NewRow();
                        dtRow["RoleId"] = objModel.UserRoleId;
                        dtRow["MenuId"] = item.MenuId;
                        dtRow["RightId"] = Enums.AccessRight.Create.GetHashCode();
                        dtTable.Rows.Add(dtRow);
                    }
                    if (item.EditRight)
                    {
                        dtRow = dtTable.NewRow();
                        dtRow["RoleId"] = objModel.UserRoleId;
                        dtRow["MenuId"] = item.MenuId;
                        dtRow["RightId"] = Enums.AccessRight.Edit.GetHashCode();
                        dtTable.Rows.Add(dtRow);
                    }
                    if (item.DeleteRight)
                    {
                        dtRow = dtTable.NewRow();
                        dtRow["RoleId"] = objModel.UserRoleId;
                        dtRow["MenuId"] = item.MenuId;
                        dtRow["RightId"] = Enums.AccessRight.Delete.GetHashCode();
                        dtTable.Rows.Add(dtRow);
                    }
                }

                GenericRepository<UserRoleModel> objGenericRepository = new GenericRepository<UserRoleModel>();

                var Result = objGenericRepository.ExecuteSQL<string>("SP_AddEditUserRoleRights",
                                    Utility.GetSQLParam("UserRoleId", SqlDbType.Int, objModel.UserRoleId),
                                    Utility.GetSQLParam("UserId", SqlDbType.Int, objModel.UserId),
                                    Utility.GetSQLParam("UserRoleRights", SqlDbType.Structured, dtTable, "dbo.tt_UserRoleRights"));
                response.Message.Add(Convert.ToString(Result.FirstOrDefault()));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message.Add(ex.Message);
                response.Success = false;
            }
            return response;
        }

        public ApiResponse<UserRightsModel> GetUserAccessRights(int UserRoleId)
        {
            ApiResponse<UserRightsModel> response = new ApiResponse<UserRightsModel>();
            try
            {
                GenericRepository<UserRightsModel> objGenericRepository = new GenericRepository<UserRightsModel>();
                var result = objGenericRepository.QuerySQL<UserRightsModel>("SP_GetUserAccessRights", Utility.GetSQLParam("UserRoleId", SqlDbType.Int, UserRoleId));
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

        public ApiPostResponse<string> GetUserMenu(int UserRoleId)
        {
            ApiPostResponse<string> response = new ApiPostResponse<string>();
            try
            {
                GenericRepository<string> objGenericRepository = new GenericRepository<string>();
                var result = objGenericRepository.QuerySQL<string>("SP_GetUserMenu", Utility.GetSQLParam("UserRoleId", SqlDbType.Int, UserRoleId));
                response.Data = result.FirstOrDefault().ToString();
                response.Success = true;
                response.Message.Add("Success");
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

