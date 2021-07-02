using _Anmol.Common;
using _Anmol.Data.Repository;
using _Anmol.Entity;
using System;
using System.Data;
using System.Linq;

namespace _Anmol.Service
{
    public class DeliveryHistoryDetailsService
    {
        public ApiResponse<CustomerMilkOrderModel> GetCustomerMilkOrderHistory(int CustId, string FromDate, string ToDate)
        {
            ApiResponse<CustomerMilkOrderModel> response = new ApiResponse<CustomerMilkOrderModel>();
            try
            {
                GenericRepository<CustomerMilkOrderModel> objGenericRepository = new GenericRepository<CustomerMilkOrderModel>();
                var result = objGenericRepository.QuerySQL<CustomerMilkOrderModel>("SP_GetCustomerMilkOrderHistory"
                    ,Utility.GetSQLParam("CustId", SqlDbType.Int, (object)CustId ?? DBNull.Value)
                    ,Utility.GetSQLParam("FromDate", SqlDbType.VarChar, (object)FromDate ?? DBNull.Value)
                    ,Utility.GetSQLParam("ToDate", SqlDbType.VarChar, (object)ToDate ?? DBNull.Value));
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
