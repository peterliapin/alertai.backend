using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlertAI.Core.Models;
using AlertAI.Core.Services;

namespace AlertAI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly TopicService _topicService;

        public TopicController(TopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetAllTopics()
        {
            var topics = await _topicService.GetAllTopics();
            return Ok(topics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Topic>> GetTopicById(int id)
        {
            var topic = await _topicService.GetTopicById(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }

        [HttpPost]
        public async Task<ActionResult<Topic>> CreateTopic(Topic topic)
        {
            var createdTopic = await _topicService.CreateTopic(topic);
            return CreatedAtAction(nameof(GetTopicById), new { id = createdTopic.Id }, createdTopic);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopic(int id, Topic topic)
        {
            if (id != topic.Id)
            {
                return BadRequest();
            }

            var existingTopic = await _topicService.GetTopicById(id);
            if (existingTopic == null)
            {
                return NotFound();
            }

            await _topicService.UpdateTopic(topic);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var existingTopic = await _topicService.GetTopicById(id);
            if (existingTopic == null)
            {
                return NotFound();
            }

            await _topicService.DeleteTopic(id);

            return NoContent();
        }
    }
}