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

        #region Client
        public const string AddEditClient = "~/Views/Client/AddEditClient.cshtml";
        #endregion

        #region Project
        public const string AddEditProject = "~/Views/Project/AddEditProject.cshtml";
        public const string ProjectSummary = "~/Views/Project/ProjectSummary.cshtml";
        #endregion

        #region ProjectDetail
        public const string AddEditProjectDetail = "~/Views/ProjectDetail/AddEditProjectDetail.cshtml";
        #endregion

        #region ProjectDetail
        public const string AddEditTransaction  = "~/Views/Transaction/AddEditTransaction.cshtml";
        #endregion

        #region ClientContact
        public const string AddEditClientContact = "~/Views/ClientContact/AddEditClientContact.cshtml";
        #endregion

        #region DevelopmentRate
        public const string AddEditDevelopmentRate = "~/Views/DevelopmentRate/AddEditDevelopmentRate.cshtml";
        #endregion
    }
}
