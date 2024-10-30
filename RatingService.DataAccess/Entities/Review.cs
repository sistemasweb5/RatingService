namespace RatingService.DataAccess.Entities;

public class Review
{
    public Guid ReviewId { get; set; }
    public string? Message { get; set; }
    public IList<string>? Images { get; set; }
    public DateTime DatePosted { get; set; }
    public Guid UserId { get; set; }
    public Guid WorkerId { get; set; }
}
