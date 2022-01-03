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
    /// Ürünler ile ilgili ekleme silme güncelleme listeleme vb. islemeleri  için hizmet sunan API Controller'dır
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        //constructor injection 
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        //Sistemde olan tüm Ürünleri listeler 

        [HttpGet("getall")]

        public IActionResult Getall()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        //Bir ürün eklemek için kullanılır
        [HttpPost("add")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);

        }


        //Bir ürünü silmek için kullanılır
        [HttpDelete("delete")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);

        }

        //Bir ürünü güncellemek için kullanılır
        [HttpPut("update")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {

                return Ok(result);

            }

            return BadRequest(result);
        }


        // id'si verilen ürünün bilgilerine ulaşmak için kullanılır
        [HttpGet("getbyid")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult GetBYId(int id)
        {
            var result = _productService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
