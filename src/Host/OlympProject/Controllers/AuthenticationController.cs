
using AppServices.Services.Account;
using Contracts.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Linq.Expressions;
using System.Net;

namespace AdBoard.Api.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public readonly IAccountService _service;
        public AuthenticationController(IAccountService service)
        {
            _service = service;
        }

        /// <summary>
        /// Регистрация аккаунта
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        [HttpPost("registration")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoAccountResponse>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Registration(RegisterOrUpdateRequest registerRequest)
        {
            if (string.IsNullOrEmpty(registerRequest.FirstName) || string.IsNullOrEmpty(registerRequest.LastName)
                || string.IsNullOrEmpty(registerRequest.Password) || string.IsNullOrEmpty(registerRequest.Email))
                return BadRequest(HttpStatusCode.BadRequest);

            var userReg = await _service.RegisterAccount(registerRequest);
            if (userReg == null)
                return Conflict(HttpStatusCode.Conflict);

            return Created("", userReg);
        }
    }
}