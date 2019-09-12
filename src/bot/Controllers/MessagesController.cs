using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using bot.Models;
using bot.Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace bot.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMessageService _messageService;

        public MessagesController(IConfiguration configuration, IMessageService messageService)
        {
            _configuration = configuration;
            _messageService = messageService;
        }

        /// <summary>
        /// Create a new message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost()]
        [SwaggerResponse(StatusCodes.Status200OK, "A new message was created")]
        [SwaggerResponse(StatusCodes.Status409Conflict, "Message already exits")]
        public async Task<IActionResult> CreateMessage(Message message, CancellationToken cancellationToken)
        {
            var result = await _messageService.CreateMessage(message, cancellationToken);

            if (result is null)
                return Conflict();

            return Ok();
        }

        /// <summary>
        /// Retrieve a message by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "The message was found", typeof(Message))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The message was not found")]
        public async Task<IActionResult> GetMessageById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _messageService.GetMessageById(id, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Retrieve all messages from conversation by conversationId
        /// </summary>
        /// <param name="conversationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet()]
        [SwaggerResponse(StatusCodes.Status200OK, "The messages from conversation were found", typeof(Message))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The messages from conversation were not found")]
        public async Task<IActionResult> GetAllMessagesByConversationId(Guid conversationId, CancellationToken cancellationToken)
        {
            var result = await _messageService.GetAllMessagesByConversationId(conversationId, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
