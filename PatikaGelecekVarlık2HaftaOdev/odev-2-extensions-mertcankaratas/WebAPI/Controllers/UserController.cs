using Business.Abstract;

using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        
        //constructor injection 
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        //Sistemde olan tüm kullanıcıları listeler 
        
        [HttpGet("getall")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Getall()
        {
            var result = _userService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Herhangi bir kullanıcı bulunmamaktadır.");
        }

        //Bir kullanıcıyı eklemek için kullanılır
        [HttpPost("add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult Add(User user)
        {
            if (user != null)
            {
                _userService.Add(user);
                return Ok("Kullanıcı Eklendi");
            }

            return BadRequest("Girilen kullanıcı bilgilerinde ekikler vardır kontrol ediniz.");
        }


        //Bir kullanıcıyı silmek için kullanılır
        [HttpDelete("delete")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult Delete(User user)
        {
            if (user != null)
            {
                _userService.Delete(user);
                return Ok("Kullanıcı Silindi");
            }

            return BadRequest("Girilen kullanıcı id'sine ait bir kayıt bulunmamaktadır. Silinemedi...");
        }

        //Bir kullanıcıyı güncellemek için kullanılır
        [HttpPut("update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult Update(User user)
        {
            if (user != null)
            {
                _userService.Update(user);
                return Ok("Kullanıcı güncellendi");
            }

            return BadRequest("Girilen kullanıcı id'sine ait bir kayıt bulunmamaktadır. Güncellenemedi...");
        }







    }
}
