using _Anmol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _Anmol.Entity;
using _Anmol.WebApp.Common;

namespace _Anmol.Web.Common
{
    public class AuthorizationHelper
    {
        public static bool IsAuthorized(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            string actionName = filterContext.ActionDescriptor.ActionName.ToLower();

            if (controllerName == "error" || controllerName == "login" || controllerName == "notification" || actionName == "openchangepasswordwindow" || actionName == "savenewpassword" || actionName == "openprofilewindow" || actionName == "saveuserprofile" || controllerName == "vehicleinspection")
            {
                return true;
            }
            else
            {
                List<UserRightsModel> userAccessRights = new List<UserRightsModel>();
                if (SessionHelper.UserAccessRights != null)
                {
                    userAccessRights = (List<UserRightsModel>)SessionHelper.UserAccessRights;
                }
                var userAccessPermissions = userAccessRights.Where(item => item.Controller != null
                    && (item.Controller.ToLower() == controllerName)
                    && (actionName.IndexOf("index") == -1 || (item.RightId == Enums.AccessRight.View.GetHashCode()))
                    && (actionName.IndexOf("create") == -1 || (item.RightId == Enums.AccessRight.Create.GetHashCode()))
                    && (actionName.IndexOf("edit") == -1 || (item.RightId == Enums.AccessRight.Edit.GetHashCode()))
                    && (actionName.IndexOf("delete") == -1 || (item.RightId == Enums.AccessRight.Delete.GetHashCode()))
                    ).ToList();

                return userAccessPermissions.Count > 0;
            }
        }

        public static bool IsAccessRightExists(string controllerName, Enums.AccessRight accessRight)
        {
            List<UserRightsModel> userAccessRights = new List<UserRightsModel>();
            if (SessionHelper.UserAccessRights != null)
            {
                userAccessRights = (List<UserRightsModel>)SessionHelper.UserAccessRights;
            }
            bool isAcees = userAccessRights.Any(item => item.Controller != null
                && item.Controller.ToLower() == controllerName.ToLower()
                && item.RightId == accessRight.GetHashCode()
            );
            return isAcees;
        }

        public static bool IsActionAccessRightExists(string controllerName, string actionname, Enums.AccessRight accessRight)
        {
            List<UserRightsModel> userAccessRights = new List<UserRightsModel>();
            if (SessionHelper.UserAccessRights != null)
            {
                userAccessRights = (List<UserRightsModel>)SessionHelper.UserAccessRights;
            }
            bool isAcees = userAccessRights.Any(item => item.Controller != null && item.Action != null
                && item.Controller.ToLower() == controllerName.ToLower()
                && item.Action.ToLower() == actionname.ToLower()
                && item.RightId == accessRight.GetHashCode()
            );
            return isAcees;
        }

        public static List<UserRightsModel> GetUserAccessRights()
        {
            var result = new ApiResponse<UserRightsModel>();
            var uri = "GetUserAccessRights?UserRoleId=" + SessionHelper.RoleId;
            result = WebApiHelper.HttpClientRequestResponseSync(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return result.Data.ToList();
            }
            else
            {
                return null;
            }
        }

        public static string GetUserMenu()
        {
            var result = new ApiPostResponse<string>();
            var uri = "GetUserMenu?UserRoleId=" + SessionHelper.RoleId;
            result = WebApiHelper.HttpClientRequestResponseSync(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return result.Data.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}