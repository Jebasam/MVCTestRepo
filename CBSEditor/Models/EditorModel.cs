using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CBSEditor.Models
{
    public class EditorModel
    {
        public string EditorContent { get; set; }
        [AllowHtml]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }

    public class FileUploadModel
    {
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string file { get; set; }

    }
    public class CKEditorModel
    {
        //[Required]
        public string emailName { get; set; }

        [Required]
        [Display(Name ="Email Content")]
        public string emailContent { get; set; }

        public string testContent { get; set; }
        public string file { get; set; }
    }


}