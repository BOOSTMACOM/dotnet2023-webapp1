using WebApplication1.Models;

namespace WebApplication1.Repositories.Interface
{
    public interface IMovieRepository : IRepository<Movie>
    {
        public void Update(Movie movie);
    }
}
