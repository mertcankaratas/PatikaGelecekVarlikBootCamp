using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Kullanıcılar ile ilgili ekleme silme güncelleme listeleme vb. islemeleri  için hizmet sunan API Controller'dır
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

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
            if (result.Success)
            {
                return Ok(result);
            }



            return BadRequest(result);

        }

        //Bir kullanıcıyı eklemek için kullanılır
        [HttpPost("add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);

        }


        //Bir kullanıcıyı silmek için kullanılır
        [HttpDelete("delete")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);

        }

        //Bir kullanıcıyı güncellemek için kullanılır
        [HttpPut("update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {

                return Ok(result);

            }

            return BadRequest(result);
        }

        //id'si verilen kullanıcının bilgilerini almak için kullanılır
        [HttpGet("getbyid")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult GetBYId(int id)
        {
            var result = _userService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
