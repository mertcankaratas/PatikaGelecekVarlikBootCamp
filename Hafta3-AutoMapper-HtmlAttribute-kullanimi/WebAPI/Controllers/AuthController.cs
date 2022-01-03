using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{/// <summary>
/// Sisteme Login olmak için hizmet sunan API Controller'dır
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public ActionResult Login(User user)
        {
            var result = _authService.Login(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

           
        }
    }
}
