using AppServices.Services.VisitedLocation;
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
        /// <param name="animalId"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="from"></param>
        /// <param name="size"></param>
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
    }
}
