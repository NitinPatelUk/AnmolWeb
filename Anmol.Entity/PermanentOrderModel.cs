using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Entity
{
    public class PermanentOrderModel
    {
        public int Id { get; set; }

        public int CustID { get; set; }

        public string CustName { get; set; }

        public string DeliveryTime { get; set; }

        public decimal Quantity { get; set; }

        public string LoggedinUserName { get; set; }

    }
}
