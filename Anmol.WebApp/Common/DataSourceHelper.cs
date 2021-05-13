using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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

        public static IEnumerable<SelectListItem> GetCowList()
        {
            var result = new ApiResponse<CowModel>();
            var uri = "GetCowList?name=" + null + "&CowId=" + null + "&gen=" + 1+"&fatherId=0&MotherId=0";
            result = WebApiHelper.HttpClientRequestResponseSync(result, uri, SessionHelper.AuthToken);
            if (result.Data != null)
            {
                IEnumerable<SelectListItem> items = result.Data
                .Select(c => new SelectListItem
                {
                    Value = Convert.ToString(c.CowID),
                    Text = c.CowID+"-"+c.CowName
                });
                return items;
            }
            else
            {
                return new List<SelectListItem>();
            }
        }

        public static IEnumerable<SelectListItem> GetBullList()
        {
            var result = new ApiResponse<CowModel>();
            var uri = "GetCowList?name=" + null + "&CowId=" + null + "&gen=" + 2+"&fatherId=0&MotherId=0";
            result = WebApiHelper.HttpClientRequestResponseSync(result, uri, SessionHelper.AuthToken);
            if (result.Data != null)
            {
                IEnumerable<SelectListItem> items = result.Data
                .Select(c => new SelectListItem
                {
                    Value = Convert.ToString(c.CowID),
                    Text = c.CowID + "-" + c.CowName
                });
                return items;
            }
            else
            {
                return new List<SelectListItem>();
            }
        }

        public static IEnumerable<SelectListItem> GetAllCowList()
        {
            var result = new ApiResponse<CowModel>();
            var uri = "GetCowList?name=" + null + "&CowId=" + null + "&gen=" + 0+ "&fatherId=0&MotherId=0";
            result = WebApiHelper.HttpClientRequestResponseSync(result, uri, SessionHelper.AuthToken);
            if (result.Data != null)
            {
                IEnumerable<SelectListItem> items = result.Data
                .Select(c => new SelectListItem
                {
                    Value = Convert.ToString(c.CowID),
                    Text = c.CowID + "-" + c.CowName
                });
                return items;
            }
            else
            {
                return new List<SelectListItem>();
            }
        }

        public static IEnumerable<SelectListItem> GetCustomerList()
        {
            var result = new ApiResponse<CustomerModel>();
            var uri = "GetCustomerList?name=" + null + "&Zipcode=" + null + "&ContactNumber=" + null + "&CustAddress=" + null;
            result = WebApiHelper.HttpClientRequestResponseSync(result, uri, SessionHelper.AuthToken);
            if (result.Data != null)
            {
                IEnumerable<SelectListItem> items = result.Data
                .Select(c => new SelectListItem
                {
                    Value = Convert.ToString(c.CustID),
                    Text = c.CustName
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