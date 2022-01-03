using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{/// <summary>
/// Kullanıcı girişlerini kontrol eden iş katmanı 
/// UserManager üstünden kullanıcıya ait email ve password değerini alır veri tabanına gider varsa giriş sağlanır
/// </summary>
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public IDataResult<User> Login(User user)
        {
            var userToCheckEmail = _userService.GetByMail(user.Email);
            if (userToCheckEmail.Success)
            {

                if (userToCheckEmail.Data.Email.Equals(user.Email) && userToCheckEmail.Data.Password.Equals(user.Password))
                {
                    user.Id = userToCheckEmail.Data.Id;
                    user.Role = userToCheckEmail.Data.Role;
                    return new SuccessDataResult<User>(Messages.UserRegistered);
                }
            }
                    
            return new ErrorDataResult<User>(Messages.CheckEmailOrPassword);
        }


        
    }
}
