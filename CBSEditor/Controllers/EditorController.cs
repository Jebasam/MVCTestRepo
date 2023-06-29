using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using Microsoft.AspNetCore.Mvc;
using CBSEditor.Logics;
using CBSEditor.Models;
//using CBSEditor.ViewModels;
using System.Text.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CBSEditor.Controllers
{
    public class ViewEditor : Controller
    {
        // GET: Editor
        private readonly HttpClient httpClient;
        private readonly HttpHelper httphelper;
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnviroment { get; set; }
        public CBSEditor.Models.ViewEditor message { get; set; }
        public ViewEditor(HttpClient _httpClient, HttpHelper _httphelper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnviroment)
        {
            this.httpClient = _httpClient;
            this.httphelper = _httphelper;
            this.hostingEnviroment = hostingEnviroment;
        }

        public IActionResult AddMessage()
        {
            return (IActionResult)View();
        }
        public IActionResult TinyMceUpload(IFormFile file)
        {
            var location = UploadImageToServer(file);
            return (IActionResult)Json(new { location });

        }

        public string UploadImageToServer(IFormFile file)
        {
            var uniqueFileName = "";
            var fullFilePath = "";
            if (file != null)
            {
                var uploadfilepath = Path.Combine(hostingEnviroment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                fullFilePath = Path.Combine(uploadfilepath, uniqueFileName);
                file.CopyTo(new FileStream(fullFilePath, FileMode.Create));
            }
            return "/Images/" + uniqueFileName;
        }

        [HttpPost]
        public IActionResult AddMessage(Models.ViewEditor p)
        {
            if (httphelper.POSTData(p, "https://localhost:44329"))
            {
                return (IActionResult)RedirectToAction("Index");

            }
            return (IActionResult)View();
        }
        public List<CBSEditor.Models.ViewEditor> Data { get; set; }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage responseMessage = httpClient.GetAsync("https://localhost:44329").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var res = await responseMessage.Content.ReadAsStreamAsync();
                Data = await JsonSerializer.DeserializeAsync<List<CBSEditor.Models.ViewEditor>>(res);
            }
            return (IActionResult)View(Data);
        }
    }
}