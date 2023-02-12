using AppServices.Services.Animal;
using AppServices.Services.AnimalType;
using Contracts.Account;
using Contracts.AnimalType;
using Contracts.LocationPoint;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace OlympProject.Controllers
{
    public class AnimalTypeController : ControllerBase
    {
        public readonly ITypeNameService _typeService;

        public AnimalTypeController(ITypeNameService typeService)
        {
            _typeService = typeService;
        }

        /// <summary>
        /// Получение информации о типе животных по ID
        /// </summary>
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

            var res = await _typeService.GetInfoAnimalType(typeId);
            if (res == null)
                return NotFound(HttpStatusCode.NotFound);

            return Ok(res);
        }

        /// <summary>
        /// Редактирование Типа животного
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPut("animals/types/{typeId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoTypeNameResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditAccount(long typeId, AddOrUpdateTypeRequest update)
        {
            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            var res = await _typeService.EditType(typeId, update);
            return Ok(res);
        }

        /// <summary>
        /// Добавление Типа животного
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        [HttpPost("animals/types")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoTypeNameResponse>), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddType(AddOrUpdateTypeRequest request)
        {
            var addPoint = await _typeService.AddType(request);
            if (request == null)
                return Conflict(HttpStatusCode.Conflict);

            return Created("", addPoint);
        }

        /// <summary>
        /// Удаление типа животного
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpDelete("animals/types/{typeId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoTypeNameResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteLocationPoint(long typeId)
        {
            if (typeId <= 0 || typeId == null)
                return BadRequest(HttpStatusCode.BadRequest);

            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            //var res = await _animalTypeService.(pointId);
            //if (res == null)
            //    return StatusCode(403);

            await _typeService.DeleteType(typeId);
            return Ok();
        }
    }
}
