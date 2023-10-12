using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ImageMagick;

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
                    using var image = new MagickImage(Path.Combine(imagesDir, fileName));
                    using var watermark = new MagickImage("watermark.png");

                    // przezroczystosc znaku wodnego
                    watermark.Evaluate(Channels.Alpha, EvaluateOperator.Divide, 4);

                    // narysowanie znaku wodnego
                    image.Composite(watermark, Gravity.Southeast, CompositeOperator.Over);

                    image.Write(Path.Combine(imagesDir, fileName));
                }
            }

            return RedirectToPage("Index");
        }
        public void OnGet()
        {

        }
    }
}