
namespace Wba.Oefening.Movies.Web.ViewModels
{
    public class PeopleIndexViewModel
    {
        public IEnumerable<BasePeopleViewModel> Directors { get; set; }
        public IEnumerable<BasePeopleViewModel> Actors { get; set; }
    }
}
