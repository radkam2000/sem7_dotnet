using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab4.Pages
{
    public class UploadModel : PageModel
    {
        [BindProperty]
        public IFormFile Upload { get; set; }
        private string imagesDir;
        public UploadModel(IWebHostEnvironment environment)
        {
            imagesDir = Path.Combine(environment.WebRootPath, "images");
        }

        public IActionResult OnPost()
        {
            if (Upload != null)
            {
                string extension = ".jpg";
                switch (Upload.ContentType)
                {
                    case "image/png":
                        extension = ".png";
                        break;
                    case "image/gif":
                        extension = ".gif";
                        break;
                }
                var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + extension;

                using (var fs = System.IO.File.OpenWrite(Path.Combine(imagesDir, fileName)))
                {
                    Upload.CopyTo(fs);
                }
            }

            return RedirectToPage("Index");
        }
        public void OnGet()
        {

        }
    }
}