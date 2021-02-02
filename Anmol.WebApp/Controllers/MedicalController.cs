using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.WebApi.Auth;
using _Anmol.WebApp.Common;
using System;
using System.IO;
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

        [JwtAuthentication]
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
                return RedirectToAction(ActionHelper.Index, ControllerHelper.Medical);
            }
        }

        [JwtAuthentication]
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
                    return View(ViewHelper.Medical);
                }
            }
            else
            {
                model.MedicalID = 0;
            }
            return View(ViewHelper.AddEditMedical, model);
        }

        [HttpPost]
        [JwtAuthentication]
        public async Task<ActionResult> SaveMedical(MedicalModel model)
        {
            try
            {
                model.LoggedinUserName = SessionHelper.LoggedInUserName;
                if (model.UploadReport != null)
                {
                    HttpPostedFileBase files = model.UploadReport;
                    model.UploadReport = null;
                    string ReportFolderName = Server.MapPath(ConfigItems.MedicalReportPath);

                    if (!Directory.Exists(ReportFolderName))
                        Directory.CreateDirectory(ReportFolderName);

                    if (files.ContentLength>0) {
                        if (model.ReportPath != null)
                        {
                            System.IO.File.Delete(model.ReportPath);
                            string fileName = DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + Path.GetExtension(files.FileName);
                            string filePath = Path.Combine(ReportFolderName, fileName);
                            files.SaveAs(filePath);
                            model.ReportPath = filePath;
                            model.ReportName = fileName;
                        }
                        else
                        {
                            string fileName = DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + Path.GetExtension(files.FileName);
                            string filePath = Path.Combine(ReportFolderName, fileName);
                            files.SaveAs(filePath);
                            model.ReportPath = filePath;
                            model.ReportName = fileName;
                        }
                    }
                }

                var response = new ApiResponse<MedicalModel>();
                var url = "SaveMedical";
                response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<MedicalModel>, MedicalModel>(model, url, SessionHelper.AuthToken);
                if (response.Success == true)
                {

                    if (model.MedicalID > 0)
                    {
                        await DataSourceHelper.SaveAuditTrail("Edit Medical Report", "Edit");
                    }
                    else
                    {
                        await DataSourceHelper.SaveAuditTrail("Add new Medical Report", "Add");
                    }
                    TempData["Message"] = model.CowID > 0 ? "Medical Report Updated Successfully" : "Cow Added Successfully";
                }
                else
                {
                    TempData["Error"] = response.Message;
                }
                return RedirectToAction("Index", ControllerHelper.Medical);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}