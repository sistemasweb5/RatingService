using MediatR;
using RatingService.DataAccess.Entities;

namespace RatingService.DataAccess.Managers.Queries;

public class GetAllReviewsQuery : IRequest<List<Review>> { }
