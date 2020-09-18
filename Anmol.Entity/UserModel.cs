using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Entity
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        public int UserRoleId { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Mobile is required.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Joining Date is required.")]
        public DateTime? JoiningDate { get; set; }
        public string StrJoiningDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public string StrLeavingDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string StrCreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string StrModifiedOn { get; set; }
        public string RoleName { get; set; }
        public int? ReportingManagerId { get; set; }
        public string LoggedinUserName { get; set; }

    }
}
