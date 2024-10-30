using MediatR;
using RatingService.DataAccess.Entities;
using RatingService.DataAccess.Interfaces;

namespace RatingService.DataAccess.Managers.Queries;

public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQuery, IList<Review>>
{
    private readonly IReviewRepository _reviewRepository;

    public GetAllReviewsQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<IList<Review>> Handle(
        GetAllReviewsQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _reviewRepository.GetAllAsync();
    }
}
