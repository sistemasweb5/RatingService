using Microsoft.EntityFrameworkCore;
using RatingService.DataAccess.Contexts;
using RatingService.DataAccess.Entities;

namespace RatingService.DataAccess.Repositories;

public class ReviewRepository
{
    private readonly BaseContext _context;

    public ReviewRepository(BaseContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(Review review)
    {
        await _context.Set<Review>().AddAsync(review);
        return await _context.SaveChangesAsync();
    }

    public async Task<IList<Review>> GetAllAsync()
    {
        return await _context.Set<Review>().ToListAsync();
    }

    public async Task<Review> GetByIdAsync(Guid id)
    {
        return await _context.Set<Review>().FindAsync(id);
    }

    public async Task<List<Review>> GetByUserIdAsync(Guid userId)
    {
        return await _context.Set<Review>().Where(r => r.UserId == userId).ToListAsync();
    }

    public async Task<List<Review>> GetByWorkerIdAsync(Guid workerId)
    {
        return await _context.Set<Review>().Where(r => r.WorkerId == workerId).ToListAsync();
    }
}
