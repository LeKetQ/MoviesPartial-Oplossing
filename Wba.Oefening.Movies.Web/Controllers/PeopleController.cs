using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Movies.Core;
using Wba.Oefening.Movies.Web.ViewModels;

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

        public IActionResult ShowDirectors()
        {
            var peopleShowDirectorsViewModelDirectors = new PeopleIndexViewModel();
            peopleShowDirectorsViewModelDirectors.Directors = _directorRepository.GetDirectors().Select(d => new BasePeopleViewModel
            {
                Name = $"{d.FirstName} {d.SurName}"
            });
            return View(peopleShowDirectorsViewModelDirectors);
        }

        public IActionResult ShowDirectorMovies(long directorId)
        {
            var directors = _movieRepository.GetMovies().Where(m => m.Directors.Any(d => d.Id == directorId));

            //
            return View();

        }

        public IActionResult ShowActors()
        {
            return View();
        }

        public IActionResult ShowActorMovies(long id)
        {
            return View();
        }
    }
}
