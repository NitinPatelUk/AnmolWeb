using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Entity
{
    public class CustomerOwnDetailsModel
    {
        public int? CustID { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string ContactNumber { get; set; }
        public decimal DailyOrder { get; set; }
    }
}
