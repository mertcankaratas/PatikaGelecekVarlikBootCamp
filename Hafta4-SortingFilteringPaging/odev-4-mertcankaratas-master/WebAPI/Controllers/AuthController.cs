using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers
{/// <summary>
/// Sisteme Login olmak için hizmet sunan API Controller'dır
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMemoryCache _memoryCache;

        public AuthController(IAuthService authService,IMemoryCache memoryCache)
        {
            _authService = authService;
            _memoryCache = memoryCache;
        }


        [HttpPost("login")]
        
        public ActionResult Login(User user)
        {
            var result = _authService.Login(user);
            if (result.Success)
            {
                if(!_memoryCache.TryGetValue("LoginUser",out  User loginUser))
                {
                    _memoryCache.Set("LoginUser", user);
                }
                return Ok(result);
            }
            return BadRequest(result);

           
        }
    }
}
