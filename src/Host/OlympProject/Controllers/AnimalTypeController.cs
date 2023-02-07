using AppServices.Services.Animal;
using AppServices.Services.AnimalType;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace OlympProject.Controllers
{
    public class AnimalTypeController : ControllerBase
    {
        public readonly IAnimalTypeService _animalTypeService;

        public AnimalTypeController(IAnimalTypeService animalTypeService)
        {
            _animalTypeService = animalTypeService;
        }

        /// <summary>
        /// Получение информации о типе животных по ID
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpGet("aninals/types/{typeId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAnimalTypeById(long typeId)
        {
            if (typeId <= 0 || typeId == null)
                return BadRequest(HttpStatusCode.BadRequest);

            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            var res = await _animalTypeService.GetInfoAnimalType(typeId);
            if (res == null)
                return NotFound(HttpStatusCode.NotFound);

            return Ok(res);
        }
    }
}
