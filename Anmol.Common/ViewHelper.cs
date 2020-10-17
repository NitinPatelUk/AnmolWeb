using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Common
{
    public class ViewHelper
    {
        #region Login
        public const string LoginView = "~/Views/Login/Index.cshtml";
        #endregion

        #region home
        public const string Index = "~/Views/Login/Index.cshtml";
        #endregion

        #region USER
        public const string User = "~/Views/User/Index.cshtml";
        public const string AddEditUser = "~/Views/User/AddEditUser.cshtml";
        #endregion

        #region COW
        public const string Cow = "~/Views/Cow/Index.cshtml";
        public const string AddEditCow = "~/Views/Cow/AddEditCow.cshtml";
        #endregion

        #region CUSTOMER
        public const string Customer = "~/Views/Customer/Index.cshtml";
        public const string AddEditCustomer = "~/Views/Customer/AddEditCustomer.cshtml";
        #endregion
    }
}
