using RatingService.DataAccess.Entities;

namespace RatingService.DataAccess.Interfaces;

public interface IReviewRepository
{
    Task<int> AddAsync(Review review);
    Task<IList<Review>> GetAllAsync();
    Task<Review> GetByIdAsync(Guid id);
    Task<List<Review>> GetByUserIdAsync(Guid userId);
    Task<List<Review>> GetByWorkerIdAsync(Guid workerId);
}
