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
    }
}
