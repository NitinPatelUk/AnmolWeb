using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _Anmol.Entity
{
    public class CustomerModel
    {
        public int CustID { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string ContactNumber { get; set; }
        public int ZipCode { get; set; }
        public string SecondaryContact { get; set; }
        public string SecondarContactNumber { get; set; }
        public bool IsActive { get; set; }
        public string LoggedinUserName { get; set; }
            
        [Required(ErrorMessage = "PassWord is required.")]
        //[MinLength(8, ErrorMessage = "Password Length Must be 8 Letter")]
        [StringLength(50,MinimumLength =8, ErrorMessage = "Password Length Must be 8 Letter")]
        public string Password { get; set; }
    }
}
