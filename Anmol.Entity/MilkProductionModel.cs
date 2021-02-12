using System;
using System.Collections.Generic;

namespace _Anmol.Entity
{
    public class MilkProductionModel
    {
        public int? MilkProductionID { get; set; }
        public DateTime? MilkingDate { get; set; }
        public int CowID { get; set; }
        public string CowName { get; set; }
        public decimal MilkQty { get; set; }
        public string MilkingTime { get; set; }
        public string LoggedinUserName { get; set; }
        public List<MilkProductionModel> CowList { get; set; }
        public List<CowQTYModel> CowQTYList { get; set; }
        public string StrCowList { get; set; }

    }
    public class CowQTYModel
    {
        public int CowID { get; set; }
        public string CowName { get; set; }
        public decimal MilkQty { get; set; }
    }

}
