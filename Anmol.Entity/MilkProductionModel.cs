using System;
namespace _Anmol.Entity
{
    public class MilkProductionModel
    { 
        public int MilkProductionID { get; set; }
        public int CowID { get; set; }
        public string CowName { get; set; }
        public decimal MilkQty { get; set; }
        public DateTime? MilkingDate { get; set; }
        public string MilkingTime { get; set; }
        public string LoggedinUserName { get; set; }
    }
}
