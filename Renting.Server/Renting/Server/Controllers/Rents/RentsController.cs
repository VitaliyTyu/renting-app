using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renting.Server.Controllers.Rents.Services;
using Renting.Server.Dtos;

namespace Renting.Server.Controllers.Rents
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RentsController : ControllerBase
    {
        private readonly IRentsService _rentsService;

        public RentsController(IRentsService rentsService)
        {
            _rentsService = rentsService;
        }

        /// <summary>
        /// Получение всех аренд
        /// </summary>
        /// <returns>Returns List<RentDto></returns>
        /// <response code="200">Success</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("Rents")]
        public async Task<List<RentDto>> GetRents(CancellationToken ct)
        {
            return await _rentsService.GetRents(ct);
        }

        /// <summary>
        /// Получение аренды
        /// </summary>
        /// <returns>Returns RentDto</returns>
        /// <response code="200">Success</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("Rent")]
        public async Task<RentDto> GetRent([FromQuery] int id, CancellationToken ct)
        {
            return await _rentsService.GetRent(id, ct);
        }
    }
}
