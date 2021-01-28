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
    public class MedicalService
    {
        public ApiResponse<MedicalModel> GetMedicalList(string name, string Heading, string Doctor, int? MedicalID)
        {
            ApiResponse<MedicalModel> response = new ApiResponse<MedicalModel>();
            try
            {
                GenericRepository<MedicalModel> objGenericRepository = new GenericRepository<MedicalModel>();
                var result = objGenericRepository.QuerySQL<MedicalModel>("SP_GetMedicalList", Utility.GetSQLParam("Name", SqlDbType.VarChar, (object)name ?? DBNull.Value)
                                                                                      , Utility.GetSQLParam("Heading", SqlDbType.VarChar, (object)Heading ?? DBNull.Value)
                                                                                      , Utility.GetSQLParam("Doctor", SqlDbType.VarChar, (object)Doctor ?? DBNull.Value)
                                                                                      , Utility.GetSQLParam("MedicalID", SqlDbType.Int, (object)MedicalID ?? DBNull.Value));
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

        public ApiPostResponse<MedicalModel> GetMedicalById(int MedicalId)
        {
            ApiPostResponse<MedicalModel> response = new ApiPostResponse<MedicalModel>();
            try
            {
                GenericRepository<MedicalModel> objGenericRepository = new GenericRepository<MedicalModel>();
                var result = objGenericRepository.QuerySQL<MedicalModel>("SP_GetMedicalById",
                    Utility.GetSQLParam("MedicalID", SqlDbType.Int, (object)MedicalId ?? DBNull.Value));
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

        public ApiResponse<MedicalModel> SaveMedical(MedicalModel model)
        {
            ApiResponse<MedicalModel> response = new ApiResponse<MedicalModel>();
            try
            {
                GenericRepository<MedicalModel> objGenericRepository = new GenericRepository<MedicalModel>();

                var result = objGenericRepository.QuerySQL<MedicalModel>("SP_AddEditMedical",
                    Utility.GetSQLParam("CowId", SqlDbType.Int, (object)model.CowID ?? DBNull.Value),
                    Utility.GetSQLParam("MedicalID", SqlDbType.Int, (object)model.MedicalID ?? DBNull.Value),
                    Utility.GetSQLParam("TreatmentDate", SqlDbType.DateTime, (object)model.TreatmentDate ?? DBNull.Value),
                    Utility.GetSQLParam("DoctorName", SqlDbType.VarChar, (object)model.DoctorName ?? DBNull.Value),
                    Utility.GetSQLParam("TreatmentNotes", SqlDbType.VarChar, (object)model.TreatmentNotes ?? DBNull.Value),
                    Utility.GetSQLParam("ReportNotes", SqlDbType.VarChar, (object)model.ReportNotes ?? DBNull.Value),
                    Utility.GetSQLParam("Heading", SqlDbType.VarChar, (object)model.Heading ?? DBNull.Value),
                    Utility.GetSQLParam("cost", SqlDbType.Decimal, (object)model.Cost ?? DBNull.Value),
                    Utility.GetSQLParam("LoggedinUserName", SqlDbType.VarChar, (object)model.LoggedinUserName ?? DBNull.Value),
                    Utility.GetSQLParam("ReportPath", SqlDbType.VarChar, (object)model.ReportPath ?? DBNull.Value),
                    Utility.GetSQLParam("ReportName", SqlDbType.VarChar, (object)model.ReportName ?? DBNull.Value)
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

        public BaseApiResponse DeleteMedical(MedicalModel model)
        {
            BaseApiResponse response = new BaseApiResponse();
            try
            {
                GenericRepository<MedicalModel> objGenericRepository = new GenericRepository<MedicalModel>();
                var result = objGenericRepository.ExecuteSQL<int>("SP_DeleteMedical",
                    Utility.GetSQLParam("MedicalID", SqlDbType.Int, (object)model.MedicalID ?? DBNull.Value));
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
