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
    public class BotsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IBotService _botService;

        public BotsController(IConfiguration configuration, IBotService botService)
        {
            _configuration = configuration;
            _botService = botService;
        }

        /// <summary>
        /// Create a new bot
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost()]
        [SwaggerResponse(StatusCodes.Status200OK, "A new bot was created")]
        [SwaggerResponse(StatusCodes.Status409Conflict, "Bot already exits")]
        public async Task<IActionResult> CreateBot(Bot bot, CancellationToken cancellationToken)
        {
            var result = await _botService.CreateBot(bot, cancellationToken);

            if (result is null)
                return Conflict();

            return Ok();
        }

        /// <summary>
        /// Retrieve a bot by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "The bot was found", typeof(Bot))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The bot was not found")]
        public async Task<IActionResult> GetBotById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _botService.GetBotById(id, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Delete a bot by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "The bot was deleted")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _botService.Delete(id, cancellationToken);

            return Ok();
        }


        /// <summary>
        /// Update a bot
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut()]
        [SwaggerResponse(StatusCodes.Status200OK, "The bot was updated")]
        public async Task<IActionResult> Update(Bot bot, CancellationToken cancellationToken)
        {
            await _botService.Update(bot, cancellationToken);

            return Ok();
        }
    }
}
