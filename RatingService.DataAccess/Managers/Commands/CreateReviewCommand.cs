using MediatR;

namespace RatingService.DataAccess.Managers.Commands;

public class CreateReviewCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public Guid WorkerId { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> Images { get; set; } = new List<string>();
}
