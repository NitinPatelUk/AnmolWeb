using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Entity
{
    public class CustomerDeliveryHistoryModel
    {
        public int SrNO { get; set; }
        public string DeliveryDate { get; set; }
        //public DateTime? DeliveryDate { get; set; }
        public int DeliveryMilk { get; set; }
    }
}
