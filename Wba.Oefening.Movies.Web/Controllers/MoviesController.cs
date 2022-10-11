using Microsoft.AspNetCore.Mvc;

namespace Wba.Oefening.Movies.Web.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
