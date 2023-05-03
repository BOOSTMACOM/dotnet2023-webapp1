using WebApplication1.Models;

namespace WebApplication1.Domain.DTO
{
	public class MovieItemDTO
	{
		public int Id { get; set; }

		public string? Title { get; set; }

		public string? Genre { get; set; }

		public MovieItemDTO() { }

		public MovieItemDTO(Movie movie) 
		{
			this.Id = movie.Id;
			this.Title = movie.Title;
			this.Genre = movie.Genre;
		}


	}
}
