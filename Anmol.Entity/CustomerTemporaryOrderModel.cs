using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Entity
{
    public class CustomerTemporaryOrderModel
    {
        public int CustTempOrdId { get; set; }
        public int CustID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DeliveryTime { get; set; }
        public decimal Quantity { get; set; }
        public string LoggedinUserName { get; set; }
    }
}
