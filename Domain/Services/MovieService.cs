using WebApplication1.Data;
using WebApplication1.Domain.Cmd;
using WebApplication1.Domain.DTO;

namespace WebApplication1.Domain.Services
{
	public class MovieService : AppService
	{
		public MovieService(WebApplication1Context context) : base(context)
		{
		}

		public IEnumerable<MovieItemDTO> GetMovieItemDTOs()
		{
			//var result = new List<MovieItemDTO>();
			var movies = _context.Movie.ToList();

			//movies.ForEach(movie => {
			//	var dto = new MovieItemDTO(movie);
			//	result.Add(dto);
			//});

			return movies.Select(movie => new MovieItemDTO(movie)).ToList(); ;

		}

		public int CreateNewMovie(CreateMovieCmd cmd)
		{
			var e =  _context.Movie.Add(cmd.ToModel());
			_context.SaveChanges();
			return e.Entity.Id;
		}

		public EditMovieCmd GetEditMovieCmd(int id) 
		{
			return new EditMovieCmd(_context.Movie.First(x => x.Id == id));
		}

		public void UpdateMovie(EditMovieCmd cmd)
		{	
			var movie = _context.Movie.FirstOrDefault(x => x.Id == cmd.Id) ?? throw new Exception("Film inexistant");
            _context.Movie.Update(cmd.ToModel(movie));
            _context.SaveChanges();		
		}
	}
}
