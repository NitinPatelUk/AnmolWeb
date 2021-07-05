using _Anmol.Common;
using _Anmol.Data.Repository;
using _Anmol.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace _Anmol.Service
{
    public class CustomerDailyDeliveryService
    {
        public BaseApiResponse CustomerDailyDelivery()
        {
            BaseApiResponse response = new BaseApiResponse();
            try
            {
                GenericRepository<CustomerModel> objGenericRepository = new GenericRepository<CustomerModel>();
                var result = objGenericRepository.ExecuteSQL<string>("SP_AddCustomerDailyDelivery");
                var data = result.ToList();                
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Message.Add(ex.Message);
                response.Success = false;                
            }
            return response;
        }

        public ApiResponse<DailyMilkDelivery> GetDailyDeliveryList(string CustName,DateTime? FromDate,DateTime? ToDate)
        {
            ApiResponse<DailyMilkDelivery> response = new ApiResponse<DailyMilkDelivery>();
            try
            {
                GenericRepository<DailyMilkDelivery> objGenericRepository = new GenericRepository<DailyMilkDelivery>();
                var result = objGenericRepository.QuerySQL<DailyMilkDelivery>("SP_GetCustomerDailyMilkDelivery"
                    , Utility.GetSQLParam("CustName", SqlDbType.VarChar, (object)CustName ?? DBNull.Value)
                    , Utility.GetSQLParam("FromDate", SqlDbType.DateTime, (object)FromDate ?? DBNull.Value)
                    , Utility.GetSQLParam("ToDate", SqlDbType.DateTime, (object)ToDate ?? DBNull.Value));
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

