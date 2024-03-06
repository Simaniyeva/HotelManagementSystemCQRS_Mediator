using IResult = HotelAPI.Application.Utilities.Results.IResult;
namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;

    public ReviewController(IReviewService ReviewService, IMapper mapper)
    {
        _reviewService = ReviewService;
        _mapper = mapper;
    }
    [HttpGet("GetReviews")]
    public async Task<IActionResult> GetReviews()
    {
        IDataResult<List<ReviewGetDto>> result = await _reviewService.GetAllAsync(true, Includes.ReviewIncludes);
        return Ok(result);

    }
    [HttpGet("GetReviewById/{id}")]
    public async Task<IActionResult> GetReviewById(int id)
    {
        IDataResult<ReviewGetDto> result = await _reviewService.GetByIdAsync(id, Includes.ReviewIncludes);
        return Ok(result);
    }

    [HttpPost("AddReview")]
    public async Task<IActionResult> AddReview(ReviewPostDto dto)
    {
        IResult result = await _reviewService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(ReviewUpdateDto dto)
    {
        await _reviewService.UpdateAsync(dto);
        return Ok();
    }
    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        ReviewGetDto result = (await _reviewService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _reviewService.SoftDeleteByIdAsync(id);
        return Ok();
    }

    [HttpPost("Recover")]

    public async Task<IActionResult> Recover(int id)
    {
        ReviewGetDto result = (await _reviewService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _reviewService.RecoverByIdAsync(id);
        return Ok();
    }


    [HttpPost("HardDelete")]
    public async Task<IActionResult> HardDelete(int id)
    {
        ReviewGetDto result = (await _reviewService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _reviewService.HardDeleteByIdAsync(id);
        return Ok();
    }

}
