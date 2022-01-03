using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ActionFilters
{ 
    //Kullanıcı Tiplerini tutuğumuz Enum bu tiplere göre yetkilendirmeler yapılmakta ve bazı işlemler kısıtlanmaktadır.
    public enum UserType
    {

        Admin,
        Seller,
        User

    }
}
