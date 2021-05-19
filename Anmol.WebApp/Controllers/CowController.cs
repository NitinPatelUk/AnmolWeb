using _Anmol.Common;
using _Anmol.Entity;
using _Anmol.WebApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
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
            ViewBag.BullList = DataSourceHelper.GetBullList();
            ViewBag.CowList = DataSourceHelper.GetCowList();
            ViewBag.GetAllCowList = DataSourceHelper.GetAllCowList();
            return View();
        }

        public FileResult GetReport(string ReportName)
        {
            string ReportFolderName = Server.MapPath(ConfigItems.MedicalReportPath);
            string ReportURL = Path.Combine(ReportFolderName, ReportName);
            //string ReportURL = "~/Document/MedicalReport/" + ReportName;
            byte[] FileBytes = System.IO.File.ReadAllBytes(ReportURL);



            //string ReportURL = "~/Document/MedicalReport/" + ReportName;
            //byte[] FileBytes = System.IO.File.ReadAllBytes(ReportURL);
            return File(FileBytes, "application/pdf");
        }

        public async Task<ActionResult> GetCowList(string name, int? CowId, string fatherid, string motherid)
        {
            int FatherId = 0;
            int MotherId = 0;
            if (fatherid != "")
                FatherId = int.Parse(fatherid);
            if (motherid != "")
                MotherId = int.Parse(motherid);
            var result = new ApiResponse<CowModel>();
            var uri = "GetCowList?name=" + name + "&cowId=" + CowId + "&gen=0&FatherId=" + FatherId + "&MotherId=" + MotherId;
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
                    if (model.FatherID != null)
                        model.FatherName = result.Data.FatherID.ToString();
                    if (model.MotherID != null)
                        model.MotherName = result.Data.MotherID.ToString();
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

        public async Task<ActionResult> GetCowDetails(int CowId)
        {
            var model = new CowModel();

            var result = new ApiResponse<CowModel>();
            var uri = "GetCowDetails?cowId=" + CowId;
            result = await WebApiHelper.HttpClientRequestResponse(result, uri, SessionHelper.AuthToken);
            if (result != null)
            {
                IList<CowModel> CowDetailsList = new List<CowModel>();
                CowDetailsList = result.Data;
                model = result.Data[0];


                foreach (var cowdetail in CowDetailsList)
                {
                    MedicalModel mm = new MedicalModel();
                    mm.TreatmentDate = cowdetail.TreatmentDate;
                    mm.TreatmentNotes = cowdetail.TreatmentNotes;
                    mm.Heading = cowdetail.TreatmentTitle;
                    mm.ReportName = cowdetail.ReportName;
                    mm.ReportNotes = cowdetail.ReportNotes;

                    model.CowMedicalDetails.Add(mm);
                }
            }
            else
            {
                TempData["Error"] = "Somthing went wrong.";
                return RedirectToAction(ActionHelper.Index, ControllerHelper.Cow);
                // return View(ViewHelper.Cow);
            }
            return View(ViewHelper.GetCowDetails, model);
        }

        [HttpPost]
        public async Task<ActionResult> SaveCow(CowModel model)
        {
            if (model.FatherName != null)
                model.FatherID = int.Parse(model.FatherName);
            if (model.MotherName != null)
                model.MotherID = int.Parse(model.MotherName);
            try
            {
                model.LoggedinUserName = SessionHelper.LoggedInUserName;
                if (model.UploadImage != null)
                {
                    HttpPostedFileBase files = model.UploadImage;
                    model.UploadImage = null;
                    string imageFolderName = Server.MapPath(ConfigItems.CowImagePath);

                    if (!Directory.Exists(imageFolderName))
                        Directory.CreateDirectory(imageFolderName);


                    if (files.ContentLength > 0)
                    {
                        if (model.ImagePath != null)
                        {
                            string path = @model.ImagePath;
                            if (System.IO.File.Exists(path))
                                System.IO.File.Delete(model.ImagePath);
                            string fileName = DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + Path.GetExtension(files.FileName);
                            string filePath = Path.Combine(imageFolderName, fileName);
                            files.SaveAs(filePath);
                            model.ImagePath = filePath;
                            model.ImageName = fileName;
                        }
                        else
                        {
                            string fileName = DateTime.Now.ToString("yyyy_MM_dd_HHmmss") + Path.GetExtension(files.FileName);
                            string filePath = Path.Combine(imageFolderName, fileName);
                            files.SaveAs(filePath);
                            model.ImagePath = filePath;
                            model.ImageName = fileName;
                        }
                    }
                }

                var response = new ApiResponse<CowModel>();
                var url = "SaveCow";
                response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<CowModel>, CowModel>(model, url, SessionHelper.AuthToken);
                if (response.Success == true)
                {

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

        public async Task<ActionResult> DeleteCow(string ImageName, int CowId = 0)
        {
            CowModel model = new CowModel();
            model.CowID = CowId;
            string imageFolderName = Server.MapPath(ConfigItems.CowImagePath);
            string filename = ImageName;
            string filePath = Path.Combine(imageFolderName, filename);
            System.IO.File.Delete(filePath);
            var response = await WebApiHelper.HttpClientPostPassEntityReturnEntity<ApiResponse<CowModel>, CowModel>(model, "DeleteCow", SessionHelper.AuthToken);
            await DataSourceHelper.SaveAuditTrail("Delete Cow", "Delete");
            return Json(new { Flag = response.Success }, JsonRequestBehavior.AllowGet);
        }

    }
}