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
    public class CustomerOwnDetailsService
    { 
        public ApiResponse<CustomerOwnDetailsModel>GetCustomerOwnDetails(int? CustID)
        {
            ApiResponse<CustomerOwnDetailsModel> response = new ApiResponse<CustomerOwnDetailsModel>();
            try
            {
                GenericRepository<CustomerOwnDetailsModel> objGenericRepository = new GenericRepository<CustomerOwnDetailsModel>();
                var result = objGenericRepository.QuerySQL<CustomerOwnDetailsModel>("SP_GetCustomerOwnDetails", Utility.GetSQLParam("Name", SqlDbType.VarChar, (object)CustID ?? DBNull.Value));
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

        public ApiPostResponse<CustomerOwnDetailsModel> GetCustomerOwndetailsById(int? CustID)
        {
            ApiPostResponse<CustomerOwnDetailsModel> response = new ApiPostResponse<CustomerOwnDetailsModel>();
            try
            {
                GenericRepository<CustomerOwnDetailsModel> objGenericRepository = new GenericRepository<CustomerOwnDetailsModel>();
                var result = objGenericRepository.QuerySQL<CustomerOwnDetailsModel>("SP_GetCustomerOwnDetails",
                    Utility.GetSQLParam("CustID", SqlDbType.Int, (object)CustID ?? DBNull.Value));
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

        public ApiResponse<CustomerOwnDetailsModel> SaveCustomerOwnDetails(CustomerOwnDetailsModel model)
        {
            ApiResponse<CustomerOwnDetailsModel> response = new ApiResponse<CustomerOwnDetailsModel>();
            try
            {
                GenericRepository<CustomerOwnDetailsModel> objGenericRepository = new GenericRepository<CustomerOwnDetailsModel>();

                var result = objGenericRepository.QuerySQL<CustomerOwnDetailsModel>("SP_EditCustomerOwnDetails",
                    Utility.GetSQLParam("CustID", SqlDbType.Int, (object)model.CustID ?? DBNull.Value),
                    Utility.GetSQLParam("CustName", SqlDbType.VarChar, (object)model.CustName ?? DBNull.Value),
                    Utility.GetSQLParam("CustAddress", SqlDbType.VarChar, (object)model.CustAddress ?? DBNull.Value),
                    Utility.GetSQLParam("ContactNumber", SqlDbType.VarChar, (object)model.ContactNumber ?? DBNull.Value),
                    Utility.GetSQLParam("Quantity", SqlDbType.Decimal, (object)model.DailyOrder ?? DBNull.Value)
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
    }

}
