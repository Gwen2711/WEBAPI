using System.ComponentModel.DataAnnotations;

public class GenreValidationAttribute : ValidationAttribute
{
    private static readonly string[] AllowedGenres =
    {
        "Action", "Comedy", "Drama", "Horror", "Sci-Fi", "Fantasy", "Thriller", "Animation", "Documentary"
    };

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string genre && AllowedGenres.Contains(genre))
        {
            return ValidationResult.Success;
        }
        return new ValidationResult($"Genre '{value}' isn't valid. Valid are: {string.Join(", ", AllowedGenres)}.");
    }
}
