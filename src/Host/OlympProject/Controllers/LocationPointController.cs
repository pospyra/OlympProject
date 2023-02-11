using AppServices.Services.LocationPoint;
using Contracts.Account;
using Contracts.LocationPoint;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace OlympProject.Controllers
{
    public class LocationPointController : ControllerBase
    {
        public readonly ILocationPointService _locationPointService;

        public LocationPointController(ILocationPointService locationPointService)
        {
            _locationPointService = locationPointService;
        }

        /// <summary>
        /// Получение информацию о точке локации животных
        /// </summary>
        /// <returns></returns>
        [HttpGet("locations/{pointId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPointById(long pointId)
        {
            if (pointId <= 0 || pointId == null)
                return BadRequest(HttpStatusCode.BadRequest);

            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            var res = await _locationPointService.GetLocationPointById(pointId);
            if (res == null)
                return NotFound(HttpStatusCode.NotFound);

            return Ok(res); 
        }

        /// <summary>
        /// Добавление точки локации
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        [HttpPost("locations")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoLocationPointResponse>), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddLocationPoint(AddOrUpdatePointRequest request)
        {
            var addPoint = await _locationPointService.AddLocation(request);
            if (request == null)
                return Conflict(HttpStatusCode.Conflict);

            return Created("", addPoint);
        }

        /// <summary>
        /// Редактирование точки локации
        /// </summary>
        /// <returns></returns>
        [HttpPut("locations/{pointId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditLocationPoint(long pointId, AddOrUpdatePointRequest update)
        {
            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            var res = await _locationPointService.EditLocation(pointId, update);
            return Ok(res);
        }

        /// <summary>
        /// Удаление точки локации
        /// </summary>
        /// <returns></returns>
        [HttpDelete("locations/{pointId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteLocationPoint(long pointId)
        {
            if (pointId <= 0 || pointId == null)
                return BadRequest(HttpStatusCode.BadRequest);

            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            var res = await _locationPointService.GetLocationPointById(pointId);
            if (res == null)
                return StatusCode(403);

            await _locationPointService.DeleteLocation(pointId);
            return Ok();
        }

    }
}
