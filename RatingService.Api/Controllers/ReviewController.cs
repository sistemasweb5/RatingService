using MediatR;
using Microsoft.AspNetCore.Mvc;
using RatingService.DataAccess.Entities;
using RatingService.DataAccess.Managers.Commands;
using RatingService.DataAccess.Managers.Queries;

namespace RatingService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReview(CreateReviewCommand command)
    {
        var reviewId = await _mediator.Send(command);
        return Ok(new { Id = reviewId });
    }

    [HttpGet]
    public async Task<ActionResult<List<Review>>> GetAllReviews()
    {
        var query = new GetAllReviewsQuery();
        var reviews = await _mediator.Send(query);

        return Ok(reviews);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReviewById(Guid id)
    {
        var query = new GetReviewByIdQuery(id);
        var review = await _mediator.Send(query);

        if (review == null)
        {
            return NotFound();
        }

        return Ok(review);
    }
}
