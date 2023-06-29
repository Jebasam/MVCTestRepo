using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CBSEditor.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;



namespace CBSEditor.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {

        //private IHostingEnvironment hostingEnvironment;

        //public HomeController(IHostingEnvironment hostingEnvironment)
        //{
        //    this.hostingEnvironment = hostingEnvironment;
        //}


        //[Route("Index")]
        //[Route("")]
        //[Route("~/")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("uploadck")]
        [HttpPost]
        public ActionResult UploadCK(HttpPostedFileBase fileUpload)
        //public ActionResult UploadCK(CKEditorModel fileUpload)
        {
            //var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileUpload.FileName;
            //var path = Path.Combine(Directory.GetCurrentDirectory(), Server.MapPath("/UploadedImages/").ToString(),fileName);
            //var stream = new FileStream(path, FileMode.Create);
            //iformfile.CopyToAsync(stream);
            //using (var stream = new FileStream(path, FileMode.Create))
            {
                //fileUpload.CopyTo(stream);
                //fileUpload.SaveAs(path);
            }
            //return new JsonResult (new { path = "/UploadedImages/" + fileName });
            //return new JsonResult (new {uploaded = 1,fileName = iformfile.FileName,url = Path.Combine("..", "UploadedFiles", "Images", "Events", iformfile.FileName)

            //});

            return View("Index");
        }


    }
}