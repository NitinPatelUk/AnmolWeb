using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Entity
{
    public class DailyMilkDelivery
    {
        public string CustName { get; set; }

        public string DeliveryTime { get; set; }

        public int? PermemetOrder { get; set; }

        public int? TempararyOrder { get; set; }

        public int FinalDelivery { get; set; }

        public decimal TotalRate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

    }
}
