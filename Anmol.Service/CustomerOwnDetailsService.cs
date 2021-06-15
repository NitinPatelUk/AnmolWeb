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
    }

}
