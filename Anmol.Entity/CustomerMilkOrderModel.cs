using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Entity
{
    public class CustomerMilkOrderModel
    {
        public int SrNO { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int TemporaryOrder { get; set; }
    }
}
