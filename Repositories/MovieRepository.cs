using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Repositories
{
    public class MovieRepository : AbstractRepository<Movie>, IMovieRepository
    {
        public MovieRepository(WebApplication1Context context) : base(context)
        {
        }

        public void Update(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException("");
            }

            _dbSet.Add(movie);
            _context.SaveChanges();
        }

    }
}
