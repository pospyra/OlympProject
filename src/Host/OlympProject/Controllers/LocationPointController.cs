using AppServices.Services.LocationPoint;
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
        /// <param name="pointId"></param>
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
    }
}
