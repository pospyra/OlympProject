using AppServices.Services.Account;
using Microsoft.AspNetCore.Mvc;

namespace OlympProject.Controllers
{
    /// <summary>
    /// Работа с Пользователями
    /// </summary>
    [Route("v1/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        public readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<>), StatusCodes.Status201Created)]
        public async Task<IActionResult> GetById(int id)
        {
             var res = await _accountService.GetAccountById(id);
            return Ok(res);
        }
    }
}
