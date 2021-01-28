using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _Anmol.Entity
{
    public class MedicalModel
    {
        public int MedicalID { get; set; }
        public int? CowID { get; set; }
        public string CowName { get; set; }
        public DateTime? TreatmentDate { get; set; }
        public string DoctorName { get; set; }
        public string TreatmentNotes { get; set; }
        public string ReportNotes { get; set; }
        public string Heading { get; set; }
        public decimal Cost { get; set; }
        public HttpPostedFileBase UploadReport { get; set; }
        public string ReportPath { get; set; }
        public string ReportName { get; set; }
        public string LoggedinUserName { get; set; }
        public string TreatDate { get; set; }
    }
}
