
namespace Wba.Oefening.Movies.Web.ViewModels
{
    public class MoviesMovieDetailViewModel
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Genre { get; set; }
        public IEnumerable<BasePeopleViewModel> Actors { get; set; }
        public IEnumerable<BasePeopleViewModel> Directors { get; set; }
    }
}
