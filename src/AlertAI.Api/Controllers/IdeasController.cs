using Microsoft.AspNetCore.Mvc;
using AlertAI.Api.Data;
using AlertAI.Api.Data.Entities;

namespace AlertAI.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class IdeasController : ControllerBase
{
    private readonly AlertAIDbContext context;

    public IdeasController(AlertAIDbContext context)
    {
        this.context = context;
    }

    // GET: api/v1/ideas
    [HttpGet]
    public ActionResult<IEnumerable<Idea>> GetIdeas()
    {
        return Ok(context.Ideas.ToList());
    }

    // GET: api/v1/ideas/{id}
    [HttpGet("{id}")]
    public ActionResult<Idea> GetIdea(Guid id)
    {
        var idea = context.Ideas.Find(id);
        if (idea == null)
        {
            return NotFound();
        }
        return Ok(idea);
    }

    // POST: api/v1/ideas
    [HttpPost]
    public ActionResult<Idea> CreateIdea([FromBody] Idea idea)
    {
        context.Ideas.Add(idea);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetIdea), new { id = idea.Id }, idea);
    }

    // PUT: api/v1/ideas/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateIdea(Guid id, [FromBody] Idea updatedIdea)
    {
        var idea = context.Ideas.Find(id);
        if (idea == null)
        {
            return NotFound();
        }
        idea.Title = updatedIdea.Title;
        context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/v1/ideas/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteIdea(Guid id)
    {
        var idea = context.Ideas.Find(id);
        if (idea == null)
        {
            return NotFound();
        }
        context.Ideas.Remove(idea);
        context.SaveChanges();
        return NoContent();
    }
}
