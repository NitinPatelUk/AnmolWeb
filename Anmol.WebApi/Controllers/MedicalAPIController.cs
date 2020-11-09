using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.Service;
using _Anmol.WebApi.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _Anmol.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class MedicalAPIController : ApiController
    {
        // GET: MedicalAPI
        private readonly MedicalService _medicalService;
        public MedicalAPIController()
        {
            _medicalService = new MedicalService();
        }

        [Route("GetMedicalList")]
        public ApiResponse<MedicalModel> GetMedicalList(string name, string Heading, string Doctor, int? MedicalID)
        {
            return _medicalService.GetMedicalList(name, Heading, Doctor, MedicalID);
        }

        [Route("GetMedicalById")]
        public ApiPostResponse<MedicalModel> GetMedicalById(int MedicalID)
        {
            return _medicalService.GetMedicalById(MedicalID);
        }

        [HttpPost]
        [Route("SaveMedical")]
        public ApiResponse<MedicalModel> SaveMedical(MedicalModel model)
        {
            return _medicalService.SaveMedical(model);
        }

        [HttpPost]
        [Route("DeleteMedical")]
        public BaseApiResponse DeleteMedical(MedicalModel model)
        {
            return _medicalService.DeleteMedical(model);
        }
    }
}