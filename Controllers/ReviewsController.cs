using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalogAPI.Data;
using System.Threading.Tasks;
using MovieCatalogAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReviewsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Review>> CreateReview(Review review)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var movie = await _context.Movies.FindAsync(review.MovieId);
        if (movie == null) return NotFound("Movie not found");

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return Ok(review);
    }
}