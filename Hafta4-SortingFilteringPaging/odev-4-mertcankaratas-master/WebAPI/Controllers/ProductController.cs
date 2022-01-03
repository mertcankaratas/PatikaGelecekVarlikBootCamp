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
       // [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult Getall()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        //verilen değerlere göre Sayfalama yapar
        [HttpGet("getallpaged")]
       // [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult GetAllPaged(int pageNumber,int elementCount)
        {
            var result = _productService.GetAllPaged(pageNumber,elementCount);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        //verilen değerlere göre sayfalama yapar filteler ve Price'a göre artan sırada listeler
        [HttpGet("getallpagedfilterasc")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult GetAllGetAllPagedFilteringSortingAsc(int pageNumber, int elementCount,string name)
        {
            var result = _productService.GetAllPagedFilteringSortingAsc(pageNumber, elementCount,name);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        //verilen değerlere göre sayfalama yapar filteler ve Price'a göre azalan sırada listeler

        [HttpGet("getallpagedfilterdesc")]
       // [ServiceFilter(typeof(ValidationFilterAttribute))]

        public IActionResult GetAllGetAllPagedFilteringSortingDesc(int pageNumber, int elementCount, string name)
        {
            var result = _productService.GetAllPagedFilteringSortingDesc(pageNumber, elementCount, name);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        //Price'a göre artan sırada sıralama yapar
        [HttpGet("getallsortasc")]
        // [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult GetAllSortingAsc()
        {
            var result = _productService.GetAllSortedAsc();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        //Price'a göre azalan sırada sıralama yapar
        [HttpGet("getallsortdesc")]
       // [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult GetAllSortingDesc()
        {
            var result = _productService.GetAllSortedDesc();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        // ürünleri Name'e göre filtelemek için kullanılır  

        [HttpGet("getallfilter")]
       // [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult GetAllSorting(string filter)
        {
            var result = _productService.GetAllFiltered(filter);
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
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
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
