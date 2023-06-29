using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;

namespace CBSEditor.Models
{
    
    public class ViewEditor
    {

        public Guid id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public IFormFile editorimage { get; set; }
    }
}