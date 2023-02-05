
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Linq.Expressions;
using System.Net;

namespace AdBoard.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {
        //public readonly IUserService _userService;

        //public AuthenticationController(IUserService userService)
        //{
        //    _userService = userService;
        //}


        [Route("api/[controller]/[action]")]
        [HttpPost()]
        [ProducesResponseType(typeof(IReadOnlyCollection<>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Registration()
        {
            return Ok();
        }
    }
}