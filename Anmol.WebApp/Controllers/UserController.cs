using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.WebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
 

namespace _Anmol.WebApp.Controllers
{
    public class UserController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.UserRoleList = DataSourceHelper.GetUserRoleItems();
            await DataSourceHelper.SaveAuditTrail("Redirect to user list page", "Redirect");
            return View();
        }

        public async Task<ActionResult> GetUserList(string name, int? roleId, string email, string mobile)
        {
            var result = new ApiResponse<UserModel>();
            var uri = "GetUserList?name=" + name + "&roleId=" + roleId + "&email=" + email + "&mobile=" + mobile;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.Index, ControllerHelper.User);
            }
        }

        public async Task<ActionResult> GetUserById(int userId)
        {
            ViewBag.UserRoleList = DataSourceHelper.GetUserRoleItems();
            BindReportingManagerList(userId);

            var model = new UserModel();
            if (userId > 0)
            {
                var result = new ApiPostResponse<UserModel>();
                var uri = "GetUserById?userId=" + userId;
                result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
                if (result.Data != null)
                {
                    model = result.Data;
                }
                else
                {
                    TempData["Error"] = "Somthing went wrong.";
                    return View(ViewHelper.User);
                }
            }
            else
            {
                model.UserId = 0;
            }
            return View(ViewHelper.AddEditUser, model);
        }

        [HttpPost]
        public async Task<ActionResult> SaveUser(UserModel model)
        {
            try
            {
                var response = new ApiResponse<UserModel>();
                model.LoggedinUserName = SessionHelper.LoggedInUserName;
                var url = "SaveUser";
                response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<UserModel>, UserModel>(model, url, SessionHelper.AuthToken);
                if (response.Success == true)
                {
                    if (model.UserId > 0)
                    {
                        await DataSourceHelper.SaveAuditTrail("Edit user", "Edit");
                    }
                    else
                    {
                        await DataSourceHelper.SaveAuditTrail("Add new user", "Add");
                    }
                    TempData["Message"] = model.UserId > 0 ? "User Updated Successfully" : "User Added Successfully";
                }
                else
                {
                    TempData["Error"] = response.Message;
                }
                return RedirectToAction("Index", ControllerHelper.User);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<ActionResult> DeleteUser(int userId = 0)
        {
            UserModel model = new UserModel();
            model.UserId = userId;
            var response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<UserModel>, UserModel>(model, "DeleteUser", SessionHelper.AuthToken);
            await DataSourceHelper.SaveAuditTrail("Delete user", "Delete");
            return Json(new { Flag = response.Success }, JsonRequestBehavior.AllowGet);
        }

        private void BindReportingManagerList(int userId)
        {
            var result = new ApiResponse<UserModel>();
            var uri = "GetUserList?name=" + null + "&roleId=" + null + "&email=" + null + "&mobile=" + null;
            result = WebApiHelper.HttpClientRequestResponseSync(result, uri, SessionHelper.AuthToken);
            if (userId > 0 && result.Data != null)
            {
                result.Data = result.Data.Where(x => x.UserId != userId).ToList();

                IEnumerable<SelectListItem> items = result.Data
                    .Select(c => new SelectListItem
                    {
                        Value = Convert.ToString(c.UserId),
                        Text = c.FullName
                    });
                ViewBag.ReportingManagerList = items;
            }
            else
            {
                ViewBag.ReportingManagerList = new List<SelectListItem>();
            }
        }
    }
}