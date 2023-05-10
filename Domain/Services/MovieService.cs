using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Domain.Cmd;
using WebApplication1.Domain.DTO;
using WebApplication1.Repositories;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Domain.Services
{
	public class MovieService : AppService
	{
		private readonly IMovieRepository repository;
		public MovieService(IMovieRepository movieRepository)
		{
			this.repository = movieRepository;
		}

        public IEnumerable<MovieItemDTO> GetMovieItemDTOs()
		{
			//var result = new List<MovieItemDTO>();
			var movies = repository.GetAll();

			//movies.ForEach(movie => {
			//	var dto = new MovieItemDTO(movie);
			//	result.Add(dto);
			//});

			return movies.Select(movie => new MovieItemDTO(movie)).ToList(); ;

		}

		public int CreateNewMovie(CreateMovieCmd cmd)
		{
			return repository.Insert(cmd.ToModel()).Id;
        }

		public EditMovieCmd GetEditMovieCmd(int id) 
		{
			var movie = repository.Get(id) ?? throw new Exception("Film inexistant");
            return new EditMovieCmd(movie);
		}

		public void UpdateMovie(EditMovieCmd cmd)
		{	
			var movie = repository.Get(cmd.Id) ?? throw new Exception("Film inexistant");

			repository.Update(cmd.ToModel(movie));
		}
	}
}
