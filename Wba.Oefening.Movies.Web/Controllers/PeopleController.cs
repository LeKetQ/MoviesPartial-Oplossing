
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Movies.Core;
using Wba.Oefening.Movies.Web.ViewModels;

namespace Wba.Oefening.Movies.Web.Controllers
{
    public class PeopleController : Controller
    {
        public readonly DirectorRepository _directorRepository;
        public readonly MovieRepository _movieRepository;
        public readonly ActorRepository _actorRepository;

        public PeopleController()
        {
            _directorRepository = new DirectorRepository();
            _movieRepository = new MovieRepository();
            _actorRepository = new ActorRepository();
        }

        #region - Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region - Show All Directors
        public IActionResult ShowDirectors()
        {
            var peopleShowDirectorsViewModel = new PeopleIndexViewModel();
            peopleShowDirectorsViewModel.Directors = _directorRepository.GetDirectors().Select(d => new BasePeopleViewModel
            {
                Id = d.Id,
                Name = $"{d.FirstName} {d.SurName}"
            });
            return View(peopleShowDirectorsViewModel);
        }
        #endregion

        #region - Show All Director Movies
        public IActionResult ShowDirectorMovies(long directorId)
        {
            var movies = _movieRepository.GetMovies().Where(m => m.Directors.Any(d => d.Id == directorId));
            var director = _directorRepository.GetDirectors().First(d => d.Id == directorId);
            
            var peopleShowDirectorMoviesViewModel = new PeopleShowDirectorMoviesViewModel();
            peopleShowDirectorMoviesViewModel.Director = $"{director.FirstName} {director.SurName}";
            peopleShowDirectorMoviesViewModel.Movies = movies.Select(m => new MoviesGetAllMoviesViewModel 
                { 
                    Id = m.Id,
                    Title = m.Title,
                    Image = m.Image,
                    Genre = m.Genre.Name
                });

            return View(peopleShowDirectorMoviesViewModel);
        }
        #endregion

        #region - Show All Actors
        public IActionResult ShowActors()
        {
            var peopleShowActorsViewModel = new PeopleIndexViewModel();
            peopleShowActorsViewModel.Actors = _actorRepository.GetActors().Select(a => new BasePeopleViewModel
            {
                Id = a.Id,
                Name = $"{a.FirstName} {a.SurName}"
            });
            return View(peopleShowActorsViewModel);
        }
        #endregion

        #region - Show All Actor Movies
        public IActionResult ShowActorMovies(long actorid)
        {
            var peopleShowActorMoviesViewModel = new PeopleShowActorMoviesViewModel();

            return View();
        }
        #endregion
    }
}
