using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Entity
{
    public class UserRightsModel
    {
        public int MenuId { get; set; }
        public int ParentMenuId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int RightId { get; set; }
        public int UserRoleId { get; set; }
        public string DisplayOrder { get; set; }
    }
}
