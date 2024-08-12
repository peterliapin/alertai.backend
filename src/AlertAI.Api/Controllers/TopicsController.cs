using Microsoft.AspNetCore.Mvc;
using AlertAI.Api.Data;
using AlertAI.Api.Data.Entities;

namespace AlertAI.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class TopicsController : ControllerBase
{
    private readonly AlertAIDbContext context;

    public TopicsController(AlertAIDbContext context)
    {
        this.context = context;
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

    [HttpPost("{id}/send-ideas")]
    public IActionResult SendIdeas(Guid id)
    {
        return Ok();
    }
}