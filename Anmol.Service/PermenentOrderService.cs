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
    public class PermenentOrderService
    {
        public ApiPostResponse<PermanentOrderModel> GetMilkOrderById(int MilkOrderId)
        {
            ApiPostResponse<PermanentOrderModel> response = new ApiPostResponse<PermanentOrderModel>();
            try
            {
                GenericRepository<PermanentOrderModel> objGenericRepository = new GenericRepository<PermanentOrderModel>();
                var result = objGenericRepository.QuerySQL<PermanentOrderModel>("SP_GetCustomerPermenentOrderById",
                    Utility.GetSQLParam("Id", SqlDbType.Int, (object)MilkOrderId ?? DBNull.Value));
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

        public BaseApiResponse DeleteMilkOrder(PermanentOrderModel model)
        {
            BaseApiResponse response = new BaseApiResponse();
            try
            {
                GenericRepository<PermanentOrderModel> objGenericRepository = new GenericRepository<PermanentOrderModel>();
                var result = objGenericRepository.ExecuteSQL<int>("SP_DeleteCustomerPermenentOrder",
                    Utility.GetSQLParam("Id", SqlDbType.Int, (object)model.Id ?? DBNull.Value));
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

        public ApiResponse<PermanentOrderModel> SaveMilkOrder(PermanentOrderModel model)
        {
            ApiResponse<PermanentOrderModel> response = new ApiResponse<PermanentOrderModel>();
            try
            {
              
                GenericRepository<PermanentOrderModel> objGenericRepository = new GenericRepository<PermanentOrderModel>();
                var result = objGenericRepository.QuerySQL<PermanentOrderModel>("SP_AddEditCustomerPermenentOrder",
                    Utility.GetSQLParam("Id", SqlDbType.Int, (object)model.Id ?? DBNull.Value),
                    Utility.GetSQLParam("CustId", SqlDbType.Int, (object)model.CustID ?? DBNull.Value),
                    Utility.GetSQLParam("DeliveryTime", SqlDbType.VarChar, (object)model.DeliveryTime ?? DBNull.Value),
                    Utility.GetSQLParam("Quantity", SqlDbType.Decimal, (object)model.Quantity ?? DBNull.Value),
                    Utility.GetSQLParam("LoggedinUserName", SqlDbType.VarChar, (object)model.LoggedinUserName ?? DBNull.Value));
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

        public ApiResponse<PermanentOrderModel> GetOrderList(string Name, string DeliveryTime)
        {
            ApiResponse<PermanentOrderModel> response = new ApiResponse<PermanentOrderModel>();
            try
            {
                GenericRepository<PermanentOrderModel> objGenericRepository = new GenericRepository<PermanentOrderModel>();
                var result = objGenericRepository.QuerySQL<PermanentOrderModel>("SP_GetCustomerPermenentOrderList"
                    , Utility.GetSQLParam("Name", SqlDbType.VarChar, (object)Name ?? DBNull.Value)
                    , Utility.GetSQLParam("DeliveryTime", SqlDbType.VarChar, (object)DeliveryTime ?? DBNull.Value));
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
