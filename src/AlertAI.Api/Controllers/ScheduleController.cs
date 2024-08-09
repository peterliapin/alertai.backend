using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlertAI.Core.Models;
using AlertAI.Core.Services;

namespace AlertAI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetAllSchedules()
        {
            var schedules = await _scheduleService.GetAllSchedules();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetScheduleById(int id)
        {
            var schedule = await _scheduleService.GetScheduleById(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> CreateSchedule(Schedule schedule)
        {
            var createdSchedule = await _scheduleService.CreateSchedule(schedule);
            return CreatedAtAction(nameof(GetScheduleById), new { id = createdSchedule.Id }, createdSchedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchedule(int id, Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return BadRequest();
            }

            var updatedSchedule = await _scheduleService.UpdateSchedule(schedule);
            if (updatedSchedule == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var deletedSchedule = await _scheduleService.DeleteSchedule(id);
            if (!deletedSchedule)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}