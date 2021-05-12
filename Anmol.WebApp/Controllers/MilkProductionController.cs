using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.WebApp.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace _Anmol.WebApp.Controllers
{
    public class MilkProductionController : Controller
    {
        // GET: MilkProduction
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetMilkProductionList(string name, int? CowId, string StartDate, string EndDate, string MilkingTime)
        {
            var result = new ApiResponse<MilkProductionModel>();
            var uri = "GetMilkProductionList?name=" + name + "&cowId=" + CowId + "&StartDate=" + StartDate + "&EndDate=" + EndDate + "&MilkingTime=" + MilkingTime;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.Index, ControllerHelper.MilkProduction);
            }
        }

        public async Task<ActionResult> AddEditMilkProduction()
        {
            MilkProductionModel model = new MilkProductionModel();
            var result = new ApiResponse<MilkProductionModel>();
            var uri = "GetMilkableCowList";
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            model.CowList = result.Data.ToList();
            model.MilkingDate = DateTime.Today;
            return View(ViewHelper.AddUpdateMilkProduction, model);
        }
        public async Task<ActionResult> SaveMilkProduction(MilkProductionModel model)
        {
            try
            {
                model.LoggedinUserName = SessionHelper.LoggedInUserName;
                model.CowQTYList = JsonConvert.DeserializeObject<List<CowQTYModel>>(model.StrCowList);
                var response = new ApiResponse<MilkProductionModel>();
                var url = "SaveMilkProduction";
                response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<MilkProductionModel>, MilkProductionModel>(model, url, SessionHelper.AuthToken);
                return RedirectToAction("Index", ControllerHelper.MilkProduction);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
        public async Task<ActionResult> DeleteMilkProduction(int MilkProductionId = 0)
        {
            MilkProductionModel model = new MilkProductionModel();
            model.MilkProductionID = MilkProductionId;
            var response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<MilkProductionModel>, MilkProductionModel>(model, "DeleteMilkProduction", SessionHelper.AuthToken);
            await DataSourceHelper.SaveAuditTrail("Delete Cow", "Delete");
            return Json(new { Flag = response.Success }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SaveMilkProductionByID(MilkProductionModel model)
        {
            try
            {
                model.LoggedinUserName = SessionHelper.LoggedInUserName;
                var response = new ApiResponse<MilkProductionModel>();
                var url = "SaveMilkProductionByID";
                response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<MilkProductionModel>, MilkProductionModel>(model, url, SessionHelper.AuthToken);
                return RedirectToAction("Index", ControllerHelper.MilkProduction);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task<ActionResult> GetMilkProductionById(int MilkProductionId = 0)
        {
            MilkProductionModel model = new MilkProductionModel();
            var result = new ApiPostResponse<MilkProductionModel>();
            var uri = "GetMilkProductionById?milkproductionid=" + MilkProductionId;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.Index, ControllerHelper.MilkProduction);
            }
        }

        private ActionResult JsonArrayAttribute(ApiResponse<MilkProductionModel> result, JsonRequestBehavior allowGet)
        {
            throw new NotImplementedException();
        }
    }
}