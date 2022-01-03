using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ActionFilters
{
    public class ValidationFilterAttribute : Attribute,IActionFilter
    {       
        private readonly IMemoryCache _memoryCache;


        public ValidationFilterAttribute(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_memoryCache.TryGetValue("LoginUser", out User loginUser))
            {
                context.Result = new UnauthorizedObjectResult("Bu işlemi gerçekleştirmek için Lütfen giriş yapınız");
            }
        }
      
    }
}
