using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AlertAI.Core.Models;
using AlertAI.Core.Services;

namespace AlertAI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification(Notification notification)
        {
            // Validate the notification data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Send the notification
            await _notificationService.SendNotification(notification);

            return Ok();
        }
    }
}