using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab4.Pages;

public class IndexModel : PageModel
{

    private string imagesDir;
    public List<string> Images { get; set; }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment environment)
    {
        imagesDir = Path.Combine(environment.WebRootPath, "images");
        _logger = logger;
    }

    public void OnGet()
    {
        UpdateFileList();
    }
    private void UpdateFileList()
    {
        Images = new List<string>();
        foreach (var item in Directory.EnumerateFiles(imagesDir).ToList())
        {
            Images.Add(Path.GetFileName(item));
        }
    }
}
