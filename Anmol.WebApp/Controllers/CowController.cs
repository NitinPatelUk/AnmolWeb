using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.WebApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _Anmol.WebApp.Controllers
{
    public class CowController : Controller
    {
        // GET: Cow
        public ActionResult Index()
        {
            ViewBag.CowList = DataSourceHelper.GetCowList();
            return View();
        }

        public async Task<ActionResult> GetAllCowList(string name, int? CowId)
        {
            var result = new ApiResponse<CowModel>();
            var uri = "GetAllCowList?name=" + name + "&cowId=" + CowId;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result.Success)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction(ActionHelper.Index, ControllerHelper.Cow);
            }
        }


            public async Task<ActionResult> GetCowById(int CowId)
            {
                ViewBag.BullList = DataSourceHelper.GetBullList();
                ViewBag.CowList = DataSourceHelper.GetCowList();
                var model = new CowModel();
                if (CowId > 0)
                {
                    var result = new ApiPostResponse<CowModel>();
                    var uri = "GetCowById?cowId=" + CowId;
                    result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
                    if (result.Data != null)
                    {
                        model = result.Data;
                    }
                    else
                    {
                        TempData["Error"] = "Somthing went wrong.";
                        return View(ViewHelper.Cow);
                    }
                }
                else
                {
                    model.CowID = 0;
                }
                return View(ViewHelper.AddEditCow, model);
        }

        [HttpPost]
        public async Task<ActionResult> SaveCow(CowModel model)
        {
            try
            {
                model.LoggedinUserName = SessionHelper.LoggedInUserName;
                List<HttpPostedFileBase> files = model.UploadImage.ToList();
                model.UploadImage = null;

                var response = new ApiResponse<CowModel>();
                var url = "SaveCow";
                response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<CowModel>, CowModel>(model, url, SessionHelper.AuthToken);
                if (response.Success == true)
                {
                    CowModel cow= response.Data == null ? null : response.Data.FirstOrDefault();
                    if (cow != null && files.Count > 0)
                    {
                        string imageFolderName = Path.Combine(ConfigItems.CowImagePath, cow.CowID.ToString()); //Ganga/Jamuna

                        if (!Directory.Exists(imageFolderName))
                            Directory.CreateDirectory(imageFolderName);

                        foreach (var file in files)
                        {
                            string fileName = model.CowID + "_" + DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + "." + Path.GetExtension(file.FileName);
                            string filePath = Path.Combine(imageFolderName, fileName);
                            file.SaveAs(filePath);
                        }
                    }

                    if (model.CowID > 0)
                    {
                        await DataSourceHelper.SaveAuditTrail("Edit Cow", "Edit");
                    }
                    else
                    {
                        await DataSourceHelper.SaveAuditTrail("Add new Cow", "Add");
                    }
                    TempData["Message"] = model.CowID > 0 ? "Cow Updated Successfully" : "Cow Added Successfully";
                }
                else
                {
                    TempData["Error"] = response.Message;
                }
                return RedirectToAction("Index", ControllerHelper.Cow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<ActionResult> DeleteCow(int CowId = 0)
        {
            CowModel model = new CowModel();
            model.CowID = CowId;
            var response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<CowModel>, CowModel>(model, "DeleteCow", SessionHelper.AuthToken);
            await DataSourceHelper.SaveAuditTrail("Delete Cow", "Delete");
            return Json(new { Flag = response.Success }, JsonRequestBehavior.AllowGet);
        }

    }
}