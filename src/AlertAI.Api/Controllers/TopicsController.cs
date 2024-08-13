using Microsoft.AspNetCore.Mvc;
using AlertAI.Api.Data;
using AlertAI.Api.Data.Entities;
using AlertAI.Api.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace AlertAI.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class TopicsController : ControllerBase
{
    private readonly AlertAIDbContext context;
    private readonly IGptService gptService;

    private readonly IEmailService emailService;

    public TopicsController(AlertAIDbContext context, IGptService gptService, IEmailService emailService)
    {
        this.context = context;
        this.gptService = gptService;
        this.emailService = emailService;
    }

    // GET: api/v1/topics
    [HttpGet]
    public ActionResult<IEnumerable<Topic>> GetTopics()
    {
        return Ok(context.Topics.ToList());
    }

    // GET: api/v1/topics/{id}
    [HttpGet("{id}")]
    public ActionResult<Topic> GetTopic(Guid id)
    {
        var topic = context.Topics.Find(id);
        if (topic == null)
        {
            return NotFound();
        }
        return Ok(topic);
    }

    // POST: api/v1/topics
    [HttpPost]
    public ActionResult<Topic> CreateTopic([FromBody] Topic topic)
    {
        context.Topics.Add(topic);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetTopic), new { id = topic.Id }, topic);
    }

    // PUT: api/v1/topics/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateTopic(Guid id, [FromBody] Topic updatedTopic)
    {
        var topic = context.Topics.Find(id);
        if (topic == null)
        {
            return NotFound();
        }
        topic.Name = updatedTopic.Name;
        context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/v1/topics/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteTopic(Guid id)
    {
        var topic = context.Topics.Find(id);
        if (topic == null)
        {
            return NotFound();
        }
        context.Topics.Remove(topic);
        context.SaveChanges();
        return NoContent();
    }
    
    /// <summary>
    /// Sends an idea for a specific topic.
    /// </summary>
    /// <param name="id">The ID of the topic.</param>
    /// <returns>An IActionResult indicating the result of the operation.</returns>
    [HttpPost("{id}/send-idea")]
    [SwaggerOperation(Summary = "Sends an idea for a specific topic")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SendIdea(Guid id)
    {
        var topic = await context.Topics.FindAsync(id);

        if (topic == null)
        {
            return NotFound();
        }

        var idea = await gptService.GenerateResponse(topic.Context, 100);

        await emailService.SendEmailAsync("peter@liapin.space", "New Idea", idea);

        return Ok();
    }

    // send-ideas API method accepting array of topic and sending ideas for all topics using SendIdea
}