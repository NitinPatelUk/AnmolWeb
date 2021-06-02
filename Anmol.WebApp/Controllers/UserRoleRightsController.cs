using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.WebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _Anmol.Service;
using System.Configuration;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using _Anmol.Web.Common;

namespace _Anmol.WebApp.Controllers
{
    public class UserRoleRightsController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }       

        public async Task<ActionResult> GetUserRoleList()
        {            
            var result = new ApiResponse<UserRoleRightsModel>();
            var uri = "GetUserRoleDetailList";
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.Index, ControllerHelper.UserRoleRights);
            }
        }

        public async Task<ActionResult> GetUserRoleRightsById(int UserRoleId)
        {
            var model = new UserRoleRightsModel();
            if (UserRoleId > 0)
            {
                model.UserRoleId = UserRoleId;
                var result = new ApiResponse<UserRoleRightsList>();
                var uri = "GetUserRoleRightsById?UserRoleId=" + UserRoleId;
                result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
                model.UserRoleRights = result.Data.ToList();
            }
            return View(ViewHelper.ManageUserRoleRights, model);
        }

        public async Task<ActionResult> SaveUserRoleRights(UserRoleRightsModel model)
        {
            string Flag = string.Empty;
            UserRoleRightsList UserRoleRightsList = new UserRoleRightsList();

            if (!string.IsNullOrEmpty(model.strRoleRights))
            {
                var serializer = new JavaScriptSerializer();
                var list = JsonConvert.DeserializeObject<List<UserRoleRightsList>>(model.strRoleRights);
                model.UserRoleRights = list;
            }

            model.UserId = SessionHelper.UserId;
            //NotificationMessage msg;
            var url = "SaveUserRoleRights";
            var response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<UserRoleRightsModel>, UserRoleRightsModel>(model, url, SessionHelper.AuthToken);
            Flag = response.Message[0].ToString();
            if (Flag.ToString() != "" && !string.IsNullOrEmpty(Flag.ToString()))
            {
                //msg = new NotificationMessage(Flag.ToString(), Enums.NotifyType.Error);
                //TempData["Message"] = msg;
                return View(ViewHelper.ManageUserRoleRights, model);
            }
            else
            {
                if (response.Success)
                {
                    TempData["Message"] = "User Role Rights Added Successfully";
                    if (model.UserRoleId > 0 && model.UserRoleId == SessionHelper.RoleId)
                    {
                        SessionHelper.Menu = AuthorizationHelper.GetUserMenu();
                        SessionHelper.UserAccessRights = AuthorizationHelper.GetUserAccessRights();
                    }
                    return RedirectToAction(ActionHelper.Index, ControllerHelper.UserRoleRights);
                }
                else
                {
                    return View(ViewHelper.ManageUserRoleRights, model);
                }
            }
        }

    }
}