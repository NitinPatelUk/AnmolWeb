﻿using _Anmol.Common;
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
    public class CowService
    {
        public ApiResponse<CowModel> GetAllCowList(string name, int? CowId)
        {
            ApiResponse<CowModel> response = new ApiResponse<CowModel>();
            try
            {
                GenericRepository<CowModel> objGenericRepository = new GenericRepository<CowModel>();
                var result = objGenericRepository.QuerySQL<CowModel>("SP_GetAllCowList", Utility.GetSQLParam("Name", SqlDbType.VarChar, (object)name ?? DBNull.Value)
                                                                                      , Utility.GetSQLParam("CowId", SqlDbType.Int, (object)CowId ?? DBNull.Value));
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

        public ApiPostResponse<CowModel> GetCowById(int cowId)
        {
            ApiPostResponse<CowModel> response = new ApiPostResponse<CowModel>();
            try
            {
                GenericRepository<CowModel> objGenericRepository = new GenericRepository<CowModel>();
                var result = objGenericRepository.QuerySQL<CowModel>("SP_GetCowById",
                    Utility.GetSQLParam("CowId", SqlDbType.Int, (object)cowId ?? DBNull.Value));
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
        public ApiResponse<CowModel> SaveCow(CowModel model)
        {
            ApiResponse<CowModel> response = new ApiResponse<CowModel>();
            try
            {
                GenericRepository<CowModel> objGenericRepository = new GenericRepository<CowModel>();

                var result = objGenericRepository.QuerySQL<CowModel>("SP_AddEditCow",
                    Utility.GetSQLParam("CowId", SqlDbType.Int, (object)model.CowID ?? DBNull.Value),
                    Utility.GetSQLParam("CowName", SqlDbType.VarChar, (object)model.CowName ?? DBNull.Value),
                    Utility.GetSQLParam("Dob", SqlDbType.DateTime, (object)model.DoB ?? DBNull.Value),
                    Utility.GetSQLParam("Dod", SqlDbType.DateTime, (object)model.DoD ?? DBNull.Value),
                    Utility.GetSQLParam("PurchaseAmt", SqlDbType.Int, (object)model.PurchaseAmt ?? DBNull.Value),
                    Utility.GetSQLParam("SalesAmt", SqlDbType.Int, (object)model.SalesAmt ?? DBNull.Value),
                    Utility.GetSQLParam("FatherID", SqlDbType.Int, (object)model.FatherID ?? DBNull.Value),
                    Utility.GetSQLParam("MotherID", SqlDbType.Int, (object)model.MotherID ?? DBNull.Value),
                    Utility.GetSQLParam("PlaceOfOrigin", SqlDbType.VarChar, (object)model.PlaceOfOrigin ?? DBNull.Value),
                    Utility.GetSQLParam("Notes", SqlDbType.VarChar, (object)model.Notes ?? DBNull.Value),
                    Utility.GetSQLParam("ImagePath", SqlDbType.VarChar, (object)model.ImagePath ?? DBNull.Value),
                    Utility.GetSQLParam("IsMilkable", SqlDbType.Bit, (object)model.IsMilkable ?? DBNull.Value), 
                    Utility.GetSQLParam("Gender", SqlDbType.VarChar, (object)model.gender ?? DBNull.Value), 
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

        public BaseApiResponse DeleteCow(CowModel model)
        {
            BaseApiResponse response = new BaseApiResponse();
            try
            {
                GenericRepository<CowModel> objGenericRepository = new GenericRepository<CowModel>();
                var result = objGenericRepository.ExecuteSQL<int>("SP_DeleteCow",
                    Utility.GetSQLParam("CowId", SqlDbType.Int, (object)model.CowID ?? DBNull.Value));
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

        public ApiResponse<CowModel> GetCowList()
        {
            ApiResponse<CowModel> response = new ApiResponse<CowModel>();
            try
            {
                GenericRepository<CowModel> objGenericRepository = new GenericRepository<CowModel>();
                var result = objGenericRepository.QuerySQL<CowModel>("SP_GetCowList");
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

        public ApiResponse<CowModel> GetBullList()
        {
            ApiResponse<CowModel> response = new ApiResponse<CowModel>();
            try
            {
                GenericRepository<CowModel> objGenericRepository = new GenericRepository<CowModel>();
                var result = objGenericRepository.QuerySQL<CowModel>("SP_GetBullList");
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