using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionFilters;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{/// <summary>
/// Sisteme Login olmak için hizmet sunan API Controller'dır
/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IDistributedCache _distributedCache;
    
        public AuthController(IAuthService authService,IDistributedCache distributedCache)
        {
            _authService = authService;
            _distributedCache = distributedCache;
          
        }


        [HttpPost("login")]
        
        public  IActionResult Login(User user)
        {
            var result =  _authService.Login(user);
            if (result.Success)
            {
                //if(!_memoryCache.TryGetValue("LoginUser",out  User loginUser))
                //{
                //    _memoryCache.Set("LoginUser", user);
                //}
                string recordKey = "User_Login_Cache";

               var caching =  _distributedCache.GetRecordAsync<User>(recordKey);
                if (caching.Result == null)
                {
                   _distributedCache.SetRecordAsync<User>(recordKey,user);
                }
                
                return Ok(result);
            }
            return BadRequest(result);

           
        }

        [HttpPost("logout")]

        public IActionResult LogOut()
        {


            string recordKey = "User_Login_Cache";

            var caching = _distributedCache.GetRecordAsync<User>(recordKey);
            if (caching.Result == null)
            {
                return BadRequest("Sisteme giriş yapmadınız böyle bir işlem gerçekleştiremezsiniz");
            }
             _distributedCache.DeleteRecordAsync<User>(recordKey);
            return Ok("Başarılı bir şekilde sistemden çıkış yaptınız.");
        }

    }
}
