using AppServices.Services.Animal;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Net;
using System.Reflection;

namespace OlympProject.Controllers
{
    public class AnimalController : ControllerBase
    {
        public readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        /// <summary>
        /// Поиск животного по ID
        /// </summary>
        /// <param name="animalId"></param>
        /// <returns></returns>
        [HttpGet("animals/{animalId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(long animalId)
        {
            if(animalId <= 0 || animalId == null)
                return BadRequest(HttpStatusCode.BadRequest);

            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            var res = await _animalService.GetAnimalById(animalId);
            if (res == null)
                return NotFound(HttpStatusCode.NotFound);

            return Ok(res);
        }

        /// <summary>
        /// Поиск животного по параметрам
        /// </summary>
        /// <param name="animalId"></param>
        /// <returns></returns>
        [HttpGet("animals/search")]
        [ProducesResponseType(typeof(IReadOnlyCollection<>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFilters(DateTime startDateTime, DateTime endDateTime, int chipperId, long chippingLocationId, string lifeStatus, string gender, int from, int size)
        {
            if (from < 0 || from == null || size <= 0 || size == null 
                || chipperId <= 0 || chippingLocationId <=0 
                || lifeStatus != "ALIVE" || lifeStatus != "DEAD"
                || gender != "MALE" ||gender != "FEMALE"
                //проверить формат даты
                )
                return BadRequest(HttpStatusCode.BadRequest);

            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            var res = await _animalService.GetAnimalByFillters(startDateTime, endDateTime, chipperId, chippingLocationId, lifeStatus, gender, from, size);
            return Ok(res);
        }
    }
}
