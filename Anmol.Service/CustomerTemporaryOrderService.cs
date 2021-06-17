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
    public class CustomerTemporaryOrderService
    {
        public ApiPostResponse<CustomerTemporaryOrderModel> GetCustomerTemporaryOrderById(int CustTempOrdId)
        {
            ApiPostResponse<CustomerTemporaryOrderModel> response = new ApiPostResponse<CustomerTemporaryOrderModel>();
            try
            {
                GenericRepository<CustomerTemporaryOrderModel> objGenericRepository = new GenericRepository<CustomerTemporaryOrderModel>();
                var result = objGenericRepository.QuerySQL<CustomerTemporaryOrderModel>("SP_GetCustomerTemporaryOrderById",
                    Utility.GetSQLParam("CustTempOrdId", SqlDbType.Int, (object)CustTempOrdId ?? DBNull.Value));
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
        public ApiResponse<CustomerTemporaryOrderModel> SaveCustomerTemporaryOrder(CustomerTemporaryOrderModel model)
        {
            ApiResponse<CustomerTemporaryOrderModel> response = new ApiResponse<CustomerTemporaryOrderModel>();
            try
            {
                GenericRepository<CustomerTemporaryOrderModel> objGenericRepository = new GenericRepository<CustomerTemporaryOrderModel>();

                var result = objGenericRepository.QuerySQL<CustomerTemporaryOrderModel>("SP_AddEditCustomerTemporaryOrder",
                    Utility.GetSQLParam("CustTempOrdId", SqlDbType.Int, (object)model.CustTempOrdId ?? DBNull.Value),
                    Utility.GetSQLParam("CustID", SqlDbType.Int, (object)model.CustID ?? DBNull.Value),
                    Utility.GetSQLParam("StartDate", SqlDbType.DateTime, (object)model.StartDate ?? DBNull.Value),
                    Utility.GetSQLParam("EndDate", SqlDbType.DateTime, (object)model.EndDate ?? DBNull.Value),
                    Utility.GetSQLParam("DeliveryTime", SqlDbType.VarChar, (object)model.DeliveryTime ?? DBNull.Value),
                    Utility.GetSQLParam("Quantity", SqlDbType.Decimal, (object)model.Quantity ?? DBNull.Value),                    
                    Utility.GetSQLParam("Reason", SqlDbType.VarChar, DBNull.Value),
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
        public BaseApiResponse DeleteCustomerTemporaryOrder(CustomerTemporaryOrderModel model)
        {
            BaseApiResponse response = new BaseApiResponse();
            try
            {
                GenericRepository<CustomerTemporaryOrderModel> objGenericRepository = new GenericRepository<CustomerTemporaryOrderModel>();
                var result = objGenericRepository.ExecuteSQL<int>("SP_DeleteCustomerTemporaryOrder",
                    Utility.GetSQLParam("CustTempOrdId", SqlDbType.Int, (object)model.CustTempOrdId ?? DBNull.Value));
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
        public ApiResponse<CustomerTemporaryOrderModel> GetCustomerTemporaryOrderList(string CustName, string DeliveryTime, string StartDate, string EndDate)
        {
            ApiResponse<CustomerTemporaryOrderModel> response = new ApiResponse<CustomerTemporaryOrderModel>();
            try
            {
                GenericRepository<CustomerTemporaryOrderModel> objGenericRepository = new GenericRepository<CustomerTemporaryOrderModel>();
                var result = objGenericRepository.QuerySQL<CustomerTemporaryOrderModel>("SP_GetCustomerTemporaryOrderList"
                    , Utility.GetSQLParam("CustName", SqlDbType.VarChar, (object)CustName ?? DBNull.Value)
                    , Utility.GetSQLParam("DeliveryTime", SqlDbType.VarChar, (object)DeliveryTime ?? DBNull.Value)
                    , Utility.GetSQLParam("StartDate", SqlDbType.VarChar, (object)StartDate ?? DBNull.Value)
                    , Utility.GetSQLParam("EndDate", SqlDbType.VarChar, (object)EndDate ?? DBNull.Value));
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
