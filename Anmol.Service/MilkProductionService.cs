﻿using _Anmol.Common;
using _Anmol.Data.Repository;
using _Anmol.Entity;
using System;
using System.Data;
using System.Linq;

namespace _Anmol.Service
{
    public class MilkProductionService
    {
        public ApiPostResponse<MilkProductionModel> GetMilkProductionById(int MilkProductionId)
        {
            ApiPostResponse<MilkProductionModel> response = new ApiPostResponse<MilkProductionModel>();
            try
            {
                GenericRepository<MilkProductionModel> objGenericRepository = new GenericRepository<MilkProductionModel>();
                var result = objGenericRepository.QuerySQL<MilkProductionModel>("SP_GetMilkProductionById",
                    Utility.GetSQLParam("MilkProductionId", SqlDbType.Int, (object)MilkProductionId ?? DBNull.Value));
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

        public BaseApiResponse DeleteMilkProduction(MilkProductionModel model)
        {
            BaseApiResponse response = new BaseApiResponse();
            try
            {
                GenericRepository<MilkProductionModel> objGenericRepository = new GenericRepository<MilkProductionModel>();
                var result = objGenericRepository.ExecuteSQL<int>("SP_DeleteMilkProduction",
                    Utility.GetSQLParam("MilkProductionID", SqlDbType.Int, (object)model.MilkProductionID ?? DBNull.Value));
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

        public ApiResponse<MilkProductionModel> SaveMilkProduction(MilkProductionModel model)
        {
            ApiResponse<MilkProductionModel> response = new ApiResponse<MilkProductionModel>();
            try
            {
                DataTable dtTable = new DataTable("CowQTYModel");
                dtTable.Columns.Add("CowID");
                dtTable.Columns.Add("MilkQty");
                foreach (var item in model.CowQTYList)
                {
                    DataRow dtRow = dtTable.NewRow();
                    dtRow["CowID"] = item.CowID;
                    dtRow["MilkQty"] = item.MilkQty;
                    dtTable.Rows.Add(dtRow);
                }
                GenericRepository<MilkProductionModel> objGenericRepository = new GenericRepository<MilkProductionModel>();
                var result = objGenericRepository.QuerySQL<MilkProductionModel>("SP_AddEditMilkProduction",
                    Utility.GetSQLParam("MilkingDate", SqlDbType.DateTime, (object)model.MilkingDate ?? DBNull.Value),
                    Utility.GetSQLParam("MilkingTime", SqlDbType.VarChar, (object)model.MilkingTime ?? DBNull.Value),
                    Utility.GetSQLParam("LoggedinUserName", SqlDbType.VarChar, (object)model.LoggedinUserName ?? DBNull.Value),
                    Utility.GetSQLParam("CowQTYModel", SqlDbType.Structured, dtTable, "dbo.MilkQTY")
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

        public ApiResponse<MilkProductionModel> GetMilkProductionList(string name, int? cowId, string StartDate, string EndDate, string milkingTime)
        {
            ApiResponse<MilkProductionModel> response = new ApiResponse<MilkProductionModel>();
            try
            {
                GenericRepository<MilkProductionModel> objGenericRepository = new GenericRepository<MilkProductionModel>();
                var result = objGenericRepository.QuerySQL<MilkProductionModel>("SP_GetMilkProductionList"
                    , Utility.GetSQLParam("name", SqlDbType.VarChar, (object)name ?? DBNull.Value)
                    , Utility.GetSQLParam("CowId", SqlDbType.Int, (object)cowId ?? DBNull.Value)
                    , Utility.GetSQLParam("milkingTime", SqlDbType.VarChar, (object)milkingTime ?? DBNull.Value)
                    , Utility.GetSQLParam("StartDate", SqlDbType.VarChar, (object)StartDate ?? DBNull.Value)
                    , Utility.GetSQLParam("EndDate", SqlDbType.VarChar, (object)EndDate ?? DBNull.Value));
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
        public ApiResponse<MilkProductionModel> SaveMilkProductionByID(MilkProductionModel model)
        {
            ApiResponse<MilkProductionModel> response = new ApiResponse<MilkProductionModel>();
            try
            {
                GenericRepository<MilkProductionModel> objGenericRepository = new GenericRepository<MilkProductionModel>();
                var result = objGenericRepository.QuerySQL<MilkProductionModel>("SP_AddEditMilkProductionById",
                    Utility.GetSQLParam("MilkProductionID", SqlDbType.Int, (object)model.MilkProductionID ?? DBNull.Value),
                    Utility.GetSQLParam("MilkQty", SqlDbType.Decimal, (object)model.MilkQty ?? DBNull.Value),
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
        public ApiResponse<MilkProductionModel> GetMilkableCowList()
        {
            ApiResponse<MilkProductionModel> response = new ApiResponse<MilkProductionModel>();
            try
            {
                GenericRepository<MilkProductionModel> objGenericRepository = new GenericRepository<MilkProductionModel>();
                var result = objGenericRepository.QuerySQL<MilkProductionModel>("SP_GetMilkableCowList");
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
