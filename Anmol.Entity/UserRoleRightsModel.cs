using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Entity
{
    public class UserRoleRightsModel
    {
        public int UserRoleId { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }
        public string strRoleRights { get; set; }

        public List<UserRoleRightsList> UserRoleRights { get; set; }
    }
    public class UserRoleRightsList
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int MenuLevel { get; set; }
        public bool ViewRight { get; set; }
        public bool EditRight { get; set; }
        public bool CreateRight { get; set; }
        public bool DeleteRight { get; set; }
    }
}
