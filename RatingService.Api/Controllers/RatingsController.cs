using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatingService.DataAccess;
using RatingService.DataAccess.Entities;

namespace RatingService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RatingsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRating(Rating rating)
        {
            await _dbContext.Ratings.AddAsync(rating);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRatingById), new { id = rating.RatingId }, rating);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings = await _dbContext.Ratings.ToListAsync();
            return Ok(ratings);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRatingById(Guid id)
        {
            var rating = await _dbContext.Ratings.FindAsync(id);
            return rating != null ? Ok(rating) : NotFound();
        }
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRating(Guid id, Rating updatedRating)
        {
            var rating = await _dbContext.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            rating.UserId = updatedRating.UserId;
            rating.AverageRating = updatedRating.AverageRating;
            rating.Count5Stars = updatedRating.Count5Stars;
            rating.Count4Stars = updatedRating.Count4Stars;
            rating.Count3Stars = updatedRating.Count3Stars;
            rating.Count2Stars = updatedRating.Count2Stars;
            rating.Count1Star = updatedRating.Count1Star;

            await _dbContext.SaveChangesAsync();
            return Ok(rating);
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRating(Guid id)
        {
            var rating = await _dbContext.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            _dbContext.Ratings.Remove(rating);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
