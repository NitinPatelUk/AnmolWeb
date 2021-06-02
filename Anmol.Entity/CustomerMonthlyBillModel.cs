using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Entity
{
    public class CustomerMonthlyBillModel
    {
        public int SrNO { get; set; }
        public string Month { get; set; }
        public double TotalQty { get; set; }
        public int Amount { get; set; }
    }
}
