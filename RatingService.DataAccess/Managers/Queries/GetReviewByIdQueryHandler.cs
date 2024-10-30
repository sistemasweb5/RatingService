using MediatR;
using RatingService.DataAccess.Entities;
using RatingService.DataAccess.Interfaces;

namespace RatingService.DataAccess.Managers.Queries;

public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, Review>
{
    private readonly IReviewRepository _reviewRepository;

    public GetReviewByIdQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<Review> Handle(
        GetReviewByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _reviewRepository.GetByIdAsync(request.Id);
    }
}
