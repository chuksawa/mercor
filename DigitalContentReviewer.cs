{\rtf1\ansi\ansicpg1252\cocoartf2870
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fswiss\fcharset0 Helvetica;}
{\colortbl;\red255\green255\blue255;}
{\*\expandedcolortbl;;}
\margl1440\margr1440\vieww19600\viewh13660\viewkind0
\pard\tx720\tx1440\tx2160\tx2880\tx3600\tx4320\tx5040\tx5760\tx6480\tx7200\tx7920\tx8640\pardirnatural\partightenfactor0

\f0\fs24 \cf0 \
// content model for submitted item and status\
Public class ContentItem \
\{\
	public int Id \{ get; set; \}\
\pard\tx720\tx1440\tx2160\tx2880\tx3600\tx4320\tx5040\tx5760\tx6480\tx7200\tx7920\tx8640\pardirnatural\partightenfactor0
\cf0 	public string Title \{ get; set; \}\
	public string Body \{ get; set; \}\
	public string AttachmentName \{ get; set; \}\
	public string Status \{ get; set; \} \
	public string SubmitterId \{ get; set; \}\
	public string ReviewerId \{ get; set; \}\
	public string ReviewComment \{ get; set; \}\
	public DateTime CreatedAt \{ get; set; \} = DateTime.UtcNow;\
\pard\tx720\tx1440\tx2160\tx2880\tx3600\tx4320\tx5040\tx5760\tx6480\tx7200\tx7920\tx8640\pardirnatural\partightenfactor0
\cf0 	\
\}\
\
// model for review details\
Public class ReviewDto\
\{\
	public string Status \{ get; set; \}\
	public string Comment \{ get; set; \}\
\}\
\
// Controller\
[ApiController]\
[Route(\'93api/[controller]\'94)]\
Public class ContentController : ControllerBase\
\{\
	private readonly ApplicationDbContext _context;\
	\
	public ContentController(ApplicationDbContext context)\
	\{\
		_context = context;\
	\}\
\
	// Submit endpoint\
	[HttpPost(\'93submit\'94)]\
	Public async Task<IActionResult> SubmitContent ([FromBody] ContentItem model)\
	\{\
		if (!ModelState.IsValid)\
		   return BadRequest(ModelState);\
\
		model.Status = \'93Pending Review\'94;\
		_context.ContentItems.Add(model);\
		await _context.SaveChangesAsync();\
\
		return Ok(\{ message = \'93Content submitted successfully\'94, model.Id \})\
	\}\
\
	//Review endpoint\
	[HttpPut(\'93review/\{id\}\'94)]\
	public async Task<IActionResult> ReviewContent(int id, [FromBody] ReviewDto reviewDto)\
	\{\
		var item = await _content.ContentItems.FindAsync(id);\
		if (item == null)\
		    return NotFound(\'93Content item not found\'94);\
\
		item.Status = reviewDto.Status\
		item.ReviewComment = reivewDto.Comment;\
\
		await _context.SaveChangesAsync();\
\
		return Ok (new \{ message $\'94Content has been \{item.Status.ToLower()\}.\'94\});\
	\}\
\
\}\
\
\
\
\
\
\
\
\
\
\
\
\
\
\
}