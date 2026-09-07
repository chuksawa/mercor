
// content model for submitted item and status
Public class ContentItem 
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Body { get; set; }
	public string AttachmentName { get; set; }
	public string Status { get; set; } 
	public string SubmitterId { get; set; }
	public string ReviewerId { get; set; }
	public string ReviewComment { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	
}

// model for review details
Public class ReviewDto
{
	public string Status { get; set; }
	public string Comment { get; set; }
}

// Controller
[ApiController]
[Route(“api/[controller]”)]
Public class ContentController : ControllerBase
{
	private readonly ApplicationDbContext _context;
	
	public ContentController(ApplicationDbContext context)
	{
		_context = context;
	}

	// Submit endpoint
	[HttpPost(“submit”)]
	Public async Task<IActionResult> SubmitContent ([FromBody] ContentItem model)
	{
		if (!ModelState.IsValid)
		   return BadRequest(ModelState);

		model.Status = “Pending Review”;
		_context.ContentItems.Add(model);
		await _context.SaveChangesAsync();

		return Ok({ message = “Content submitted successfully”, model.Id })
	}

	//Review endpoint
	[HttpPut(“review/{id}”)]
	public async Task<IActionResult> ReviewContent(int id, [FromBody] ReviewDto reviewDto)
	{
		var item = await _content.ContentItems.FindAsync(id);
		if (item == null)
		    return NotFound(“Content item not found”);

		item.Status = reviewDto.Status
		item.ReviewComment = reivewDto.Comment;

		await _context.SaveChangesAsync();

		return Ok (new { message $”Content has been {item.Status.ToLower()}.”});
	}

}














