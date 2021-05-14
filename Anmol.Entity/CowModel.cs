using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace _Anmol.Entity
{
    public class CowModel
    {
        public int CowID { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string CowName { get; set; }
        public int? CowPin { get; set; }
        public DateTime? DoB { get; set; }
        public DateTime? DoD { get; set; }
        public int? PurchaseAmt { get; set; }
        public int? SalesAmt { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int? FatherID { get; set; }
        public int? MotherID { get; set; }
        public string PlaceOfOrigin { get; set; }
        public string Notes { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public bool IsMilkable { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public string gender { get; set; }
        public string LoggedinUserName { get; set; }
        public HttpPostedFileBase UploadImage { get; set; }
        public int? Lactation { get; set; }
        public string TreatmentTitle { get; set; }
        public DateTime? TreatmentDate { get; set; }
        public string TreatmentNotes { get; set; }
        public string ReportName { get; set; }
        public string ReportNotes { get; set; }
        public decimal LastProduction { get; set; }
        public decimal Last7DaysProduction { get; set; }
        public decimal Last30DaysProduction { get; set; }
        public decimal Last365DaysProduction { get; set; }

    }

}
