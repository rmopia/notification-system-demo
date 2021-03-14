using Microsoft.AspNetCore.Mvc;
using NotificationSystemDemo.Models;
using NotificationSystemDemo.Services;

// .net core 3.1

namespace NotificationSystemDemo.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly NotificationService notificationService;

        public NotificationsController()
        {
            notificationService = new NotificationService();
        }

        // POST: api/notifications/sms
        [HttpPost("sms")]
        public IActionResult SendAndStoreSMS([FromBody] SmsModel smsModel)
        {
            notificationService.SendAndStoreSMS(smsModel);

            // TODO: return responses based on SendAndStoreSMS outcome i.e. 200, 400, etc.
            return Ok();
        }

        // POST: api/notifications/email
        [HttpPost("email")]
        public IActionResult SendAndStoreEmails([FromBody] EmailModel emailModel)
        {
            notificationService.SendAndStoreEmail(emailModel);

            // TODO: return responses based on SendAndStoreEmail outcome i.e. 200, 400, etc.
            return Ok();
        }
    }
}
