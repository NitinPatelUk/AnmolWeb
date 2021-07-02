using _Anmol.Common;
using _Anmol.Data.Repository;
using _Anmol.Entity;
using System;
using System.Data;
using System.Linq;

namespace _Anmol.Service
{
    public class MilkOrderDetailsService
    {
        public ApiResponse<CustomerMilkOrderModel> GetMilkOrderList(int CustId)
        {
            ApiResponse<CustomerMilkOrderModel> response = new ApiResponse<CustomerMilkOrderModel>();
            try
            {
                GenericRepository<CustomerMilkOrderModel> objGenericRepository = new GenericRepository<CustomerMilkOrderModel>();
                var result = objGenericRepository.QuerySQL<CustomerMilkOrderModel>("SP_GetMilkOrderDetailsList"
                    , Utility.GetSQLParam("CustId", SqlDbType.Int, (object)CustId ?? DBNull.Value));
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

        public ApiResponse<CustomerMilkOrderModel> SaveCustomerTemporaryMilkOrder(CustomerMilkOrderModel model)
        {
            ApiResponse<CustomerMilkOrderModel> response = new ApiResponse<CustomerMilkOrderModel>();
            try
            {
                GenericRepository<CustomerMilkOrderModel> objGenericRepository = new GenericRepository<CustomerMilkOrderModel>();

                var result = objGenericRepository.QuerySQL<CustomerMilkOrderModel>("SP_AddEditCustomerTemporaryOrder",
                    Utility.GetSQLParam("CustTempOrdId", SqlDbType.Int, (object)model.CustTempOrdId ?? DBNull.Value),
                    Utility.GetSQLParam("CustID", SqlDbType.Int, (object)model.CustID ?? DBNull.Value),
                    Utility.GetSQLParam("StartDate", SqlDbType.DateTime, (object)model.FromDate ?? DBNull.Value),
                    Utility.GetSQLParam("EndDate", SqlDbType.DateTime, (object)model.ToDate ?? DBNull.Value),
                    Utility.GetSQLParam("DeliveryTime", SqlDbType.VarChar, DBNull.Value),
                    Utility.GetSQLParam("Quantity", SqlDbType.Decimal, (object)model.TemporaryOrder ?? DBNull.Value),
                    Utility.GetSQLParam("Reason", SqlDbType.VarChar, (object)model.Reason ?? DBNull.Value),
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

        //public BaseApiResponse DeleteCow(CowModel model)
        //{
        //    BaseApiResponse response = new BaseApiResponse();
        //    try
        //    {
        //        GenericRepository<CowModel> objGenericRepository = new GenericRepository<CowModel>();
        //        var result = objGenericRepository.ExecuteSQL<int>("SP_DeleteCow",
        //            Utility.GetSQLParam("CowId", SqlDbType.Int, (object)model.CowID ?? DBNull.Value));
        //        if (result.FirstOrDefault() > 0)
        //        {
        //            response.Success = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message.Add(ex.Message);
        //        response.Success = false;
        //    }
        //    return response;
        //}        
    }
}
