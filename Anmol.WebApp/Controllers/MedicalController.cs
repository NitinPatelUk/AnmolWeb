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
    public class MedicalController : Controller
    {
        // GET: Medical
        public ActionResult Index()
        {
            ViewBag.CowList = DataSourceHelper.GetCowList();
            return View();
        }

        public async Task<ActionResult> GetMedicalList(string name, string Heading, string Doctor, int? MedicalID)
        {
            var result = new ApiResponse<MedicalModel>();
            var uri = "GetMedicalList?name=" + name + "&Heading" + Heading + "&Doctor=" + Doctor + "&medicalId=" + MedicalID ;
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


        public async Task<ActionResult> GetMedicalById(int MedicalID)
        {
            ViewBag.CowList = DataSourceHelper.GetAllCowList();
            var model = new MedicalModel();
            if (MedicalID > 0)
            {
                var result = new ApiPostResponse<MedicalModel>();
                var uri = "GetMedicalById?medicalId=" + MedicalID;
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
                model.MedicalID = 0;
            }
            return View(ViewHelper.AddEditMedical, model);
        }

        [HttpPost]
        public async Task<ActionResult> SaveMedical(MedicalModel model)
        {
            try
            {
                model.LoggedinUserName = SessionHelper.LoggedInUserName;
                List<HttpPostedFileBase> files = model.UploadReport.ToList();
                model.UploadReport = null;

                var response = new ApiResponse<MedicalModel>();
                var url = "SaveMedical";
                response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<MedicalModel>, MedicalModel>(model, url, SessionHelper.AuthToken);
                if (response.Success == true)
                {
                    MedicalModel medical = response.Data == null ? null : response.Data.FirstOrDefault();
                    if (medical != null && files.Count > 0)
                    {
                        string imageFolderName = Server.MapPath(ConfigItems.MedicalReportPath);
                        imageFolderName = Path.Combine(imageFolderName, medical.MedicalID.ToString()); //Ganga/Jamuna

                        if (!Directory.Exists(imageFolderName))
                            Directory.CreateDirectory(imageFolderName);

                        foreach (var file in files)
                        {
                            string fileName = model.MedicalID + "_" + DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + "." + Path.GetExtension(file.FileName);
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
    }
}