using AppServices.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Net;

namespace OlympProject.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        public readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Поиск аккаунта по ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("/accounts/{accountId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int accountId)
        {
            if (accountId <= 0 || accountId == null)
                return BadRequest(HttpStatusCode.BadRequest);

            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            var res = await _accountService.GetAccountById(accountId);
            if (res == null)
                return NotFound(HttpStatusCode.NotFound);

            return Ok(res);
        }

        /// <summary>
        /// Поиск аккаунта по параметрам
        /// </summary>
        /// <returns></returns>
        [HttpGet("/accounts/search")]
        [ProducesResponseType(typeof(IReadOnlyCollection<>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAccountsByFillters(string? firstName, string? lastName, string? email, int from, int size)
        {
            if (from < 0 || from == null || size <= 0 || size == null)
                return BadRequest(HttpStatusCode.BadRequest);

            string currentUser = "";
            if (currentUser == null)
                return Unauthorized(HttpStatusCode.Unauthorized);

            var res = await _accountService.GetAccountByFillters(firstName, lastName, email, from, size);
            return Ok(res);
        }
    }
}
