using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Domain.Cmd
{
    public class EditMovieCmd
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Le titre ne doit pas être vide !")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Le genre ne doit pas être vide !")]
        public string? Genre { get; set; }

        public EditMovieCmd() { }

        public EditMovieCmd(Movie movie) 
        {
            Id = movie.Id;
            Title = movie.Title;
            Genre = movie.Genre;
        }

        public Movie ToModel(Movie movie)
        {
            movie.Title = Title;
            movie.Genre = Genre;

            return movie;
        }
    }
}
