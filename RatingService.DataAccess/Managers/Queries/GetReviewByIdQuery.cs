using MediatR;
using RatingService.DataAccess.Entities;

namespace RatingService.DataAccess.Managers.Queries;

public class GetReviewByIdQuery : IRequest<Review>
{
    public Guid Id { get; set; }

    public GetReviewByIdQuery(Guid id)
    {
        Id = id;
    }
}
