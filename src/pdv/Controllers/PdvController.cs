using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;
using pdv.Services;
using pdv.Models;

namespace pdv.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PdvController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly PdvService _pdvService;

        public PdvController(IConfiguration configuration, PdvService pdvService)
        {
            _configuration = configuration;
            _pdvService = pdvService;
        }

        /// <summary>
        /// Create a new PDV
        /// </summary>
        /// <param name="pdv"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [SwaggerResponse(StatusCodes.Status200OK, "A new PDV was created")]
        [SwaggerResponse(StatusCodes.Status409Conflict, "PDV already exits")]
        public async Task<IActionResult> CreatePdv(Pdv pdv, CancellationToken cancellationToken)
        {
            var result = await _pdvService.CreatePdv(pdv, cancellationToken);

            if (result is null)
                return Conflict();

            return Ok();
        }

        /// <summary>
        /// Retrieve a PDV by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("getById/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "The PDV was found", typeof(Pdv))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The PDV was not found")]
        public async Task<IActionResult> GetPdvById(string id, CancellationToken cancellationToken)
        {
            var result = await _pdvService.GetPdvById(id, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Retrieve a PDV by longitude and latitude
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("search/{lng}/{lat}")]
        [SwaggerResponse(StatusCodes.Status200OK, "The PDV was found", typeof(IEnumerable<Pdv>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The PDV was not found")]
        public async Task<IActionResult> SearchPdv(double lng, double lat, CancellationToken cancellationToken)
        {
            var result = await _pdvService.SearchPdv(lng, lat, cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
