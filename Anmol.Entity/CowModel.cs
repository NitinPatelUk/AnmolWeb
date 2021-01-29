﻿using System;
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
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LoggedinUserName { get; set; }
        public HttpPostedFileBase UploadImage { get; set; }
    }

}
