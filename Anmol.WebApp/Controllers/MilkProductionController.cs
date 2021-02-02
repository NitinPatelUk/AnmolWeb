using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.WebApp.Common;
using System;
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
        public async Task<ActionResult> GetMilkProductionList(string name, int? CowId,DateTime? MilkingDate,string MilkingTime)
        {
            var result = new ApiResponse<MilkProductionModel>();
            var uri = "GetMilkProductionList?name=" + name + "&cowId=" + CowId + "&MilkingDate=" + MilkingDate + "&MilkingTime=" + MilkingTime;
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
        public async Task<ActionResult> AddUpdateMilkProduction()
        {
            var result = new ApiResponse<CowModel>();
            var uri = "GetMilkableCowList";
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return View(ViewHelper.AddUpdateMilkProduction,result);
            }
            else
            {
                return RedirectToAction(ActionHelper.Index, ControllerHelper.Cow);
            }
        }


    }
}