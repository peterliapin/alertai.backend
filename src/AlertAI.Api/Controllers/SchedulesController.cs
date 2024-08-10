using Microsoft.AspNetCore.Mvc;
using AlertAI.Api.Data;
using AlertAI.Api.Data.Entities;

namespace AlertAI.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SchedulesController : ControllerBase
    {
        private readonly AlertAIDbContext context;

        public SchedulesController(AlertAIDbContext context)
        {
            this.context = context;
        }

        // GET: api/v1/schedules
        [HttpGet]
        public ActionResult<IEnumerable<Schedule>> GetSchedules()
        {
            return Ok(context.Schedules.ToList());
        }

        // GET: api/v1/schedules/{id}
        [HttpGet("{id}")]
        public ActionResult<Schedule> GetSchedule(Guid id)
        {
            var schedule = context.Schedules.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }

        // POST: api/v1/schedules
        [HttpPost]
        public ActionResult<Schedule> CreateSchedule([FromBody] Schedule schedule)
        {
            context.Schedules.Add(schedule);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetSchedule), new { id = schedule.Id }, schedule);
        }

        // PUT: api/v1/schedules/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSchedule(Guid id, [FromBody] Schedule updatedSchedule)
        {
            var schedule = context.Schedules.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }
            context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/v1/schedules/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSchedule(Guid id)
        {
            var schedule = context.Schedules.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }
            context.Schedules.Remove(schedule);
            context.SaveChanges();
            return NoContent();
        }
    }
}