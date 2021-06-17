using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Entity
{
    public class CustomerMilkOrderModel
    {
        public int CustTempOrdId { get; set; }
        public int CustID { get; set; }
        public string strFromDate { get; set; }
        public string strToDate { get; set; }
        public decimal? TemporaryOrder { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; }
        public string LoggedinUserName { get; set; }
    }
}
