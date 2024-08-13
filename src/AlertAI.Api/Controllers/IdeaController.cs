using Microsoft.AspNetCore.Mvc;
using AlertAI.Api.Data;
using AlertAI.Api.Data.Entities;

namespace AlertAI.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class IdeaController : ControllerBase
{
    private readonly AlertAIDbContext context;

    public IdeaController(AlertAIDbContext context)
    {
        this.context = context;
    }

    // GET: api/idea
    [HttpGet]
    public ActionResult<IEnumerable<Idea>> GetIdeas()
    {
        return Ok(context.Ideas.ToList());
    }

    // GET: api/idea/{id}
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

    // POST: api/idea
    [HttpPost]
    public ActionResult<Idea> CreateIdea([FromBody] Idea idea)
    {
        context.Ideas.Add(idea);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetIdea), new { id = idea.Id }, idea);
    }

    // PUT: api/idea/{id}
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

    // DELETE: api/idea/{id}
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
