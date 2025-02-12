using System.ComponentModel.DataAnnotations;

namespace MovieCatalogAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [GenreValidation]
        public string Genre { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
