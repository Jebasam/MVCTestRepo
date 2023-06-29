using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CBSEditor.Controllers
{
    public class CKEditorController : Controller
    {
        // GET: CKEditor
        public ActionResult Index(string edit)
        {
            if (edit != null)
            {
                Models.CKEditorModel ckEditor = new Models.CKEditorModel();
                ckEditor.emailName = ((MyStruct)Session["TempEmailSession"]).emailName;
                ckEditor.emailContent = ((MyStruct)Session["TempEmailSession"]).emailContent;
                return View(ckEditor);
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(Models.CKEditorModel ckEditor)
        {
            if (ModelState.IsValid)
            {
                MyStruct myStruct;
                myStruct.emailName = ckEditor.emailName;
                myStruct.emailContent = ckEditor.emailContent;
                Session["TempEmailSession"] = myStruct;
                ViewBag.StudentData = BindDataTable();
                ViewBag.Result = "Form Submitted Successfully";
            }
            else
                ViewBag.Result = "Invalid Entries, Kindly Recheck.";
            return View();
        }

        struct MyStruct
        {
            public string emailName;
            public string emailContent;
        }

        string BindDataTable()
        {
            string table = "<table>";
            table += "<tr><td class=\"red\">Name: </td></tr><tr><td>" + ((MyStruct)Session["TempEmailSession"]).emailName + "</td></tr>";
            table += "</table>";
            table += "<div><div class=\"red\">Description: </div></div><div><div>" + ((MyStruct)Session["TempEmailSession"]).emailContent + "</div></div>";
            
            return table;
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return RedirectToAction("Index", "CKEditor", new { edit = "edit" });
        }
    }
}