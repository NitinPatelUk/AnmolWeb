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
    public class CustomerService
    {
        public ApiResponse<CustomerModel> GetCustomerList(string name, int? Zipcode, string ContactNumber, string CustAddress)
        {
            ApiResponse<CustomerModel> response = new ApiResponse<CustomerModel>();
            try
            {
                GenericRepository<CustomerModel> objGenericRepository = new GenericRepository<CustomerModel>();
                var result = objGenericRepository.QuerySQL<CustomerModel>("SP_GetCustomerList", Utility.GetSQLParam("Name", SqlDbType.VarChar, (object)name ?? DBNull.Value)
                                                                                      , Utility.GetSQLParam("Zipcode", SqlDbType.Int, (object)Zipcode ?? DBNull.Value)
                                                                                      , Utility.GetSQLParam("ContactNumber", SqlDbType.VarChar, (object)ContactNumber ?? DBNull.Value)
                                                                                      , Utility.GetSQLParam("CustAddress", SqlDbType.VarChar, (object)CustAddress ?? DBNull.Value));
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

        public ApiPostResponse<CustomerModel> GetCustomerById(int custId)
        {
            ApiPostResponse<CustomerModel> response = new ApiPostResponse<CustomerModel>();
            try
            {
                GenericRepository<CustomerModel> objGenericRepository = new GenericRepository<CustomerModel>();
                var result = objGenericRepository.QuerySQL<CustomerModel>("SP_GetCustomerById",
                    Utility.GetSQLParam("CustId", SqlDbType.Int, (object)custId ?? DBNull.Value));
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
        public ApiResponse<CustomerModel> SaveCustomer(CustomerModel model)
        {
            ApiResponse<CustomerModel> response = new ApiResponse<CustomerModel>();
            try
            {
                GenericRepository<CustomerModel> objGenericRepository = new GenericRepository<CustomerModel>();

                var result = objGenericRepository.QuerySQL<CustomerModel>("SP_AddEditCustomer",
                    Utility.GetSQLParam("CustID", SqlDbType.Int, (object)model.CustID ?? DBNull.Value),
                    Utility.GetSQLParam("CustName", SqlDbType.VarChar, (object)model.CustName ?? DBNull.Value),
                    Utility.GetSQLParam("CustAddress", SqlDbType.VarChar, (object)model.CustAddress ?? DBNull.Value),
                    Utility.GetSQLParam("ContactNumber", SqlDbType.VarChar, (object)model.ContactNumber ?? DBNull.Value),
                    Utility.GetSQLParam("ZipCode", SqlDbType.Int, (object)model.ZipCode ?? DBNull.Value),
                    Utility.GetSQLParam("SecondaryContact", SqlDbType.VarChar, (object)model.SecondaryContact ?? DBNull.Value),
                    Utility.GetSQLParam("SecondarContactNumber", SqlDbType.VarChar, (object)model.SecondarContactNumber ?? DBNull.Value),
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

        public BaseApiResponse DeleteCustomer(CustomerModel model)
        {
            BaseApiResponse response = new BaseApiResponse();
            try
            {
                GenericRepository<CustomerModel> objGenericRepository = new GenericRepository<CustomerModel>();
                var result = objGenericRepository.ExecuteSQL<int>("SP_DeleteCustomer",
                    Utility.GetSQLParam("CustId", SqlDbType.Int, (object)model.CustID ?? DBNull.Value));
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
    }
}
