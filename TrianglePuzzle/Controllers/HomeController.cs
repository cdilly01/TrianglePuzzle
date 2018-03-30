using System.Web.Mvc;
using TrianglePuzzle.Models;

namespace TrianglePuzzle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
