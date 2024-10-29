using MediatR;
using RatingService.DataAccess.Entities;
using RatingService.DataAccess.Interfaces;

namespace RatingService.DataAccess.Managers.Commands;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Guid>
{
    private readonly IReviewRepository _reviewRepository;

    public CreateReviewCommandHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = new Review
        {
            ReviewId = Guid.NewGuid(),
            UserId = request.UserId,
            WorkerId = request.WorkerId,
            Message = request.Message,
            Images = request.Images,
            DatePosted = DateTime.UtcNow,
        };

        await _reviewRepository.AddAsync(review);
        return review.ReviewId;
    }
}
