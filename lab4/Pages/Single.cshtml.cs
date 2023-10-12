using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab4.Pages
{
    public class SingleModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Image { get; set; }
        private string imagesDir;

        public SingleModel(IWebHostEnvironment environment)
        {
            imagesDir = Path.Combine(environment.WebRootPath, "images");
        }

        public IActionResult OnGet()
        {
            if (!System.IO.File.Exists(Path.Combine(imagesDir, Image)))
            {
                return NotFound();
            }
            return Page();
        }
    }
}