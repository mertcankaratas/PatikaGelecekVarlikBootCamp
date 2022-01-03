using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ActionFilters
{
    public class ValidationFilterAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //loglama burada yapıldı
            var time = DateTime.Now;
            var message = "Bu tarihte islem gerceklesti" + time;
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //kullanıcı türü enum üstünde attandı ve kontrol edildi admin olduğunda işlemleri gerçekleştirebilmekteyiz
            UserType userType = UserType.Admin;
            if (userType!=UserType.Admin)
            {
                context.Result = new BadRequestObjectResult("object is null");
                return;
            }
        }
    }
}
