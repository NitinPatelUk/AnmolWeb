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
    public class MonthlyBillService
    {
        public ApiResponse<MonthlyBillModel> GetMonthlyBillList(string CustName,string BillMonth)
        {
            ApiResponse<MonthlyBillModel> response = new ApiResponse<MonthlyBillModel>();
            try
            {
                GenericRepository<MonthlyBillModel> objGenericRepository = new GenericRepository<MonthlyBillModel>();
                var result = objGenericRepository.QuerySQL<MonthlyBillModel>("SP_GetMonthlyBill"
                    , Utility.GetSQLParam("CustName", SqlDbType.VarChar, (object)CustName ?? DBNull.Value)
                    , Utility.GetSQLParam("BillMonth", SqlDbType.VarChar, (object)BillMonth ?? DBNull.Value));
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
