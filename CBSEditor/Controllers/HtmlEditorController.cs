using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CBSEditor.Models;

namespace CBSEditor.Controllers
{
    public class HtmlEditorController : Controller
    {
        // GET: HtmlEditor
        public ActionResult Index()
        {
            EditorModel model = new EditorModel();
            model.EditorContent = "Initial Content";
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveEditorContent(EditorModel model)
        {
            // Save the HTML content to the database or perform other operations
            // Example: Save the content to a property of your model
            var savedContent = model.EditorContent;

            return RedirectToAction("Index",savedContent);
        }
    }
}