using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Entity
{
    public class CustomerTemporaryOrderModel
    {
        public int? CustTempOrdId { get; set; }
        [Required(ErrorMessage ="Customer name is Required")]
        public int CustID { get; set; }
        public string CustName { get; set; }

        [Required(ErrorMessage ="Start Date is Required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage ="End Date is Reuired")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage ="Delivery Time is Required")]
        public string DeliveryTime { get; set; }

        [Required(ErrorMessage ="Quantity is Required")]
        public decimal Quantity { get; set; }
        public string LoggedinUserName { get; set; }
    }
}
