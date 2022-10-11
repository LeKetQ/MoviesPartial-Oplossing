using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Movies.Core;

namespace Wba.Oefening.Movies.Web.Controllers
{
    public class PeopleController : Controller
    {
        public readonly DirectorRepository _directorRepository;
        public readonly MovieRepository _movieRepository;

        public PeopleController()
        {
            _directorRepository = new DirectorRepository();
            _movieRepository = new MovieRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowDirectorMovies(long id)
        {
            var directors = _movieRepository.GetMovies().Where(m => m.Directors.Any(d => d.Id == id));
            // get data

            //
            return View();
            // LINQ Any
        }
    }
}
