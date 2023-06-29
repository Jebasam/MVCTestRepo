using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace CBSEditor.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload    
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase file)
        //public ActionResult UploadFiles(IFormFile file)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    if (file != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/UploadedImages"), Path.GetFileName(file.FileName));
                        
                        //path = Path.ChangeExtension(path, "jpg");
                        file.SaveAs(path);

                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {

                    ViewBag.FileStatus = "Error while file uploading.";
                }

            }
            return View("Index");
        }
    }
}