using AppServices.Services.Animal;
using Contracts.Animal;
using Contracts.AnimalDto;
using Contracts.AnimalType;
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
        /// <returns></returns>
        [HttpGet("animals/{animalId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoAnimalResponse>), (int)HttpStatusCode.OK)]
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
        /// <returns></returns>
        [HttpGet("animals/search")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoAnimalResponse>), (int)HttpStatusCode.OK)]
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

        /// <summary>
        /// Добавлене животного
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("animals")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoAnimalResponse>), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddType(AddAnimalRequest request)
        {
            var addPoint = await _animalService.AddAnimal(request);
            if (request == null)
                return Conflict(HttpStatusCode.Conflict);

            return Created("", addPoint);
        }

        /// <summary>
        /// Редактирование данных живльного
        /// </summary>
        /// <returns></returns>
        [HttpPut("animals/{aniamlId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoAnimalResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditAnimal(long aniamlId, UpdateAnimalRequest update)
        {
            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            var res = await _animalService.EditAnimal(aniamlId, update);
            return Ok(res);
        }

        /// <summary>
        /// Удаление животного
        /// </summary>
        /// <param name="animalId"></param>
        /// <returns></returns>
        [HttpDelete("animals/{animalId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoAnimalResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteLocationPoint(long animalId)
        {
            if (animalId <= 0 || animalId == null)
                return BadRequest(HttpStatusCode.BadRequest);

            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            //var res = await _animalTypeService.(pointId);
            //if (res == null)
            //    return StatusCode(403);

            await _animalService.DeleteAnimal(animalId);
            return Ok();
        }
    }


}
