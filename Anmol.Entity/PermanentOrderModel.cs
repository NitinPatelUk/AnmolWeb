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

        public int CustTD { get; set; }

        public string DeliveryTime { get; set; }

        public int Quantity { get; set; }

        public string LoggedinUserName { get; set; }

    }
}
