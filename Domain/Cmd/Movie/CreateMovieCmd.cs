using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Domain.Cmd
{
	public class CreateMovieCmd
	{
		[Required(ErrorMessage = "Le titre est obligatoire")]
		public string? Title { get; set; }

        [Required(ErrorMessage = "Le genre est obligatoire")]
        public string? Genre { get; set; }

		public DateTime ReleaseDate { get; set; }

		public decimal Price { get; set; }

		public CreateMovieCmd() { }

		public Movie ToModel()
		{
			return new Movie
			{
				Title = Title,
				Genre = Genre,
				ReleaseDate = ReleaseDate,
				Price = Price,
			};
		}
    }
}
