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

        #region MEDICAL
        public const string Medical = "~/Views/Medical/Index.cshtml";
        public const string AddEditMedical = "~/Views/Medical/AddEditMedical.cshtml";
        #endregion

        #region MILK PRODUCTION
        public const string MilkProduction = "~/Views/MilkProduction/Index.cshtml";
        public const string AddUpdateMilkProduction = "~/Views/MilkProduction/AddUpdateMilkProduction.cshtml";
        #endregion

        #region CUSTOMER TEMPORARY ORDER
        public const string CustomerTemporaryOrder = "~/Views/CustomerTemporaryOrder/Index.cshtml";
        public const string AddEditCustomerTemporaryOrder = "~/Views/CustomerTemporaryOrder/AddEditCustomerTemporaryOrder.cshtml";
        public const string AddEditCustomerTemporaryOrderCustomer = "~/Views/CustomerTemporaryOrder/AddEditCustomerTemporaryOrderCustomer.cshtml";
        public const string GetMilkOrderDetail = "~/Views/MilkOrderDetails/GetMilkOrderDetail.cshtml";
        #endregion

        #region Customer Permanent Order
        public const string PermanentOrder = "~/Views/PermenentOrder/Index.cshtml";
        public const string AddEditPermanentOrder = "~/Views/PermenentOrder/AddEditPermenentOrder.cshtml";
        #endregion

        #region Customer Own Details
        public const string GetCustomerOwnDetails = "~/Views/CustomerOwnDetails/GetCustomerOwnDetails.cshtml";
        public const string EditCustomerOwnDetails = "~/Views/CustomerOwndetails/EditCustomerOwnDetails.cshtml";
#endregion

    }
}
