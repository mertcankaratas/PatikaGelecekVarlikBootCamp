using AutoMapper;
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
    /// Kategoriler ile ilgili ekleme silme güncelleme listeleme vb. islemeleri  için hizmet sunan API Controller'dır
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        IMapper _mapper;
        //constructor injection 
        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        //Sistemde olan tüm Kategorileri listeler 

        [HttpGet("getall")]
        

        public IActionResult Getall()
        {
            var result = _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        //Bir Kategori eklemek için kullanılır
        [HttpPost("add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);

        }


        //Bir Kategoriyi silmek için kullanılır
        [HttpDelete("delete")]

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Delete(Category category)
        {
            var result = _categoryService.Delete(category);
            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);

        }

        //Bir Kategoriyi güncellemek için kullanılır
        [HttpPut("update")]

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            if (result.Success)
            {

                return Ok(result);

            }

            return BadRequest(result);
        }


        //Bir id alıp ilgili kategorinin bilgilerini almak için kullanılır
        [HttpGet("getbyid")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult GetBYId(int id)
        {
            var result = _categoryService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
