using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _Anmol.Common;
using _Anmol.Entity;

namespace _Anmol.WebApp.Common
{
    public static class DataSourceHelper
    {
        [HttpPost]
        public static async Task<ActionResult> SaveAuditTrail(string Action, string ActionType)
        {
            var result = new ApiResponse<LoginModel>();
            var uri = "SaveAuditTrail?Action=" + Action + "&UserId=" + SessionHelper.LoggedInUserName + "&ActionType=" + ActionType;
            result = await WebApiHelper.HttpClientPost(result, uri);
            return null;
        }

        public static IEnumerable<SelectListItem> GetUserRoleItems()
        {
            var result = new ApiResponse<UserRoleModel>();
            var uri = "GetUserRoleList";
            result = WebApiHelper.HttpClientRequestResponseSync(result, uri, SessionHelper.AuthToken);
            if (result.Data != null)
            {
                IEnumerable<SelectListItem> items = result.Data
                .Select(c => new SelectListItem
                {
                    Value = Convert.ToString(c.UserRoleId),
                    Text = c.RoleName
                });
                return items;
            }
            else
            {
                return new List<SelectListItem>();
            }
        }
         

        public static IEnumerable<SelectListItem> UserList()
        {
            var result = new ApiResponse<UserModel>();
            var uri = "GetUserList?name=" + null + "&roleId=" + null + "&email=" + null + "&mobile=" + null;
            result = WebApiHelper.HttpClientRequestResponseSync(result, uri, SessionHelper.AuthToken);
            if (result.Data != null)
            {
                IEnumerable<SelectListItem> items = result.Data
                .Select(c => new SelectListItem
                {
                    Value = Convert.ToString(c.UserId),
                    Text = c.FullName
                });
                return items;
            }
            else
            {
                return new List<SelectListItem>();
            }
        }
 
 


    }
}