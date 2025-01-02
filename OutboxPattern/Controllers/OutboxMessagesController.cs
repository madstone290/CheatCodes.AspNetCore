using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using OutboxPattern.Core.Domain;
using OutboxPattern.Core.Infrastructure;
using OutboxPattern.Core.Infrastructure.OutboxPayloads;
using System.Text.Json;

namespace OutboxPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutboxMessagesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly OutboxMessagePublisher _outboxService;

        public OutboxMessagesController(ApplicationDbContext dbContext, OutboxMessagePublisher outboxService)
        {
            _dbContext = dbContext;
            _outboxService = outboxService;
        }

        [HttpPost]
        public ActionResult CreatOrder()
        {
            var order = Order.Create("James Lee", "LA, 1023", "Pen");

            var randomNumber = Random.Shared.Next(1, 100);
            if (randomNumber % 2 == 0)
            {
                var emailPayload = new EmailPayload()
                {
                    To = "abc@gmail.com",
                    Subject = "Order Created",
                    Body = "Your order has been created: " + order.Product,
                };
                _outboxService.PublishMessage(nameof(EmailPayload), emailPayload);
            }
            else
            {
                var payload = new NotificationPayload()
                {
                    Message = "Order Created",
                    Recipient = order.CustomerName,
                    RetryCount = 3,
                    Limit = DateTime.UtcNow,
                    IsError = Random.Shared.Next(1, 100) % 5 != 0
                };
                _outboxService.PublishMessage(nameof(NotificationPayload), payload);
            }

            _dbContext.SaveChanges();

            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult> GetOutboxMessages()
        {
            var messages = await _dbContext.OutboxMessages.ToListAsync();
            return Ok(messages);
        }


        [HttpGet("Uncompleted")]
        public async Task<ActionResult> GetUncompletedMessages()
        {
            var messages = await _dbContext.OutboxMessages.Where(x=> !x.IsCompleted).ToListAsync();
            return Ok(messages);
        }


        [HttpGet("Completed")]
        public async Task<ActionResult> GetCompletedMessages()
        {
            var messages = await _dbContext.OutboxMessages.Where(x => x.IsCompleted).ToListAsync();
            return Ok(messages);
        }

        [HttpGet("Failed")]
        public async Task<ActionResult> GetFailedMessages()
        {
            var messages = await _dbContext.OutboxMessages.Where(x => !x.IsSuccessful).ToListAsync();
            return Ok(messages);
        }


        [HttpGet("Succeeded")]
        public async Task<ActionResult> GetSucceededMessages()
        {
            var messages = await _dbContext.OutboxMessages.Where(x => x.IsSuccessful).ToListAsync();
            return Ok(messages);
        }
    }
}
