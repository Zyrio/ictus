using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ictus.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [Route("/")]
        [Route("/{repository}")]
        [Route("/{repository}/{fileId}")]
        public IActionResult Index(string repository, string fileId)
        {
            ViewBag.SiteDescription = Ictus.Data.Constants.AppSettingsConstant.SiteDescription;
            ViewBag.SiteIcon = "fa-" + Ictus.Data.Constants.AppSettingsConstant.SiteIcon;
            ViewBag.SiteName = Ictus.Data.Constants.AppSettingsConstant.SiteName;
            ViewBag.IsYiffco = true;

            if(ViewBag.SiteName != "Yiff.co") {
                ViewBag.IsYiffco = false;
            }

            if(Ictus.Data.Constants.VersionConstant.Patch == 0) {
                ViewBag.Version = Ictus.Data.Constants.VersionConstant.Release.ToString();
            } else {
                ViewBag.Version = Ictus.Data.Constants.VersionConstant.Release.ToString() + "." +
                    Ictus.Data.Constants.VersionConstant.Patch.ToString();
            }

            if(Ictus.Data.Constants.VersionConstant.Unstable) {
                ViewBag.Version += "-dev";
            }

            return View("Index");
        }

        [Route("/frame/comment/{repository}/{fileId}")]
        public IActionResult Comment(string repository, string fileId)
        {
            return View("Comment");
        }

        public string Error()
        {
            return "If you can see this message, something has gone terribly wrong.";
        }
    }
}
