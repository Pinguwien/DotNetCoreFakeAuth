using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeAuth.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProtectedController : ControllerBase
    {
        private readonly ILogger<ProtectedController> _logger;

        public ProtectedController(ILogger<ProtectedController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            
            //just to get something back which shows which options is used
            var userId = identity?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var email = identity?.FindFirst(ClaimTypes.Email).Value;
            var name = identity?.FindFirst(ClaimTypes.Name).Value;
            
            return Ok(new[]
            {
                userId,
                email,
                name
            });
        }
    }
}