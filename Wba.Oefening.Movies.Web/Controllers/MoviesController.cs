using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Wba.Oefening.Movies.Core;
using Wba.Oefening.Movies.Web.Models;
using Wba.Oefening.Movies.Web.ViewModels;

namespace Wba.Oefening.Movies.Web.Controllers
{
    public class MoviesController : Controller
    {
        public readonly MovieRepository _movieRepository;
        public MoviesController()
        {
            _movieRepository = new MovieRepository();
        }
        public IActionResult Index()
        {
            var moviesIndexViewModel = new MoviesIndexViewModel();
            moviesIndexViewModel.Movies = _movieRepository.GetMovies().Select(m => new MoviesGetAllMoviesViewModel
            {
                Id = m?.Id,
                Title = m?.Title ?? "No Title",
                Image = m?.Image ?? "placeholder.jpg",
                Genre = m?.Genre.Name ??"No Genre"
            });
            return View(moviesIndexViewModel);
        }

        public IActionResult ShowMovie(Guid movieId)
        {
            var movie = _movieRepository.GetMovies().FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                return View("Error", new ErrorViewModel());
            }
            else
            {
                var moviesMovieDetailViewModel = new MoviesMovieDetailViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Image = movie.Image,
                    Genre = movie.Genre.Name,
                    Actors = movie.Actors.Select(m => new BasePeopleViewModel
                    {
                        Name = $"{m.FirstName} {m.SurName}"
                    }),
                    Directors = movie.Directors.Select(m => new BasePeopleViewModel
                    {
                        Name = $"{m.FirstName} {m.SurName}"
                    })

                };
                return View(moviesMovieDetailViewModel);
            }
        }
    }
}

