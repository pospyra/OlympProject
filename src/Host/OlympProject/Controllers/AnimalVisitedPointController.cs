using AppServices.Services.VisitedLocation;
using Contracts.Animal;
using Contracts.AnimalType;
using Contracts.VisitedLocationDto;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection;

namespace OlympProject.Controllers
{
    public class AnimalVisitedPointController : ControllerBase
    {
        public readonly IVisitedLocationService _visitedLocationService;

        public AnimalVisitedPointController(IVisitedLocationService visitedLocationService)
        {
            _visitedLocationService = visitedLocationService;
        }

        /// <summary>
        /// Просмотр информации о перемещении животного
        /// </summary>
        /// <returns></returns>
        [HttpGet("animals/{animalId}/locations")]
        [ProducesResponseType(typeof(IReadOnlyCollection<>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetVisitedLocation(long animalId, DateTime startDateTime, DateTime endDateTime, int from, int size)
        {
            if (from < 0 || from == null || size <= 0 || size == null
                || animalId <= 0 || animalId <= 0
                //проверка формата даты
                )
                return BadRequest(HttpStatusCode.BadRequest);

            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            var res = await _visitedLocationService.GetVisitedLocation(animalId, startDateTime, endDateTime, from, size);
            if(res == null)
                return NotFound(HttpStatusCode.NotFound);

            return Ok(res);
        }

        /// <summary>
        /// Изменение информации о посещенной точке
        /// </summary>
        /// <returns></returns>
        [HttpPut("animals/{animalId}/locations")]
        [ProducesResponseType(typeof(IReadOnlyCollection<VisitedLocationResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditVisitedLocation(long animalId, EditVisitedLocationRequest update)
        {
            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            var res = await _visitedLocationService.EditVisitedLocation(animalId, update);
            return Ok(res);
        }

        /// <summary>
        /// Добавление посещенной точки
        /// </summary>>
        /// <returns></returns>
        [HttpPost("animals/{animalId}/locations/{pointId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<VisitedLocationResponse>), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddVisLocation(long animalId, long pointId)
        {
            var addPoint = await _visitedLocationService.AddVisitedLocation(animalId, pointId);
            if (addPoint == null)
                return Conflict(HttpStatusCode.Conflict);

            return Created("", addPoint);
        }

        [HttpDelete("animals/{animalId}/locations/{visitedPointId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoAnimalResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteVisLocation(long animalId, long visitedPointId)
        {
            if (animalId <= 0 || animalId == null)
                return BadRequest(HttpStatusCode.BadRequest);

            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            //var res = await _animalTypeService.(pointId);
            //if (res == null)
            //    return StatusCode(403);

            await _visitedLocationService.DeleteVisitedPoint(animalId, visitedPointId);
            return Ok();
        }
    }
}
