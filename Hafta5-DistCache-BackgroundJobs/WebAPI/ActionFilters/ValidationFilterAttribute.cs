using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Extensions;

namespace WebAPI.ActionFilters
{
    public class ValidationFilterAttribute : Attribute, IActionFilter
    {
        private readonly IDistributedCache _distributedCache;
    
        public ValidationFilterAttribute(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
           
        }



        //private readonly IMemoryCache _memoryCache;


        //public ValidationFilterAttribute(IMemoryCache memoryCache)
        //{
        //    _memoryCache = memoryCache;

        //}

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string recordKey = "User_Login_Cache";
            var cache = _distributedCache.GetRecordAsync<User>(recordKey);

            if (cache.Result == null)
            {
                //context.Result = new UnauthorizedObjectResult("Bu işlemi gerçekleştirmek için Lütfen giriş yapınız");
                context.Result = new UnauthorizedObjectResult(new ErrorResult(Messages.LoginRequired));
                return;
            }

            if (cache.Result.Role != "admin")
            {
                context.Result = new UnauthorizedObjectResult(new ErrorResult(Messages.AuthorizationDenied));

            }

        }
    }
}
