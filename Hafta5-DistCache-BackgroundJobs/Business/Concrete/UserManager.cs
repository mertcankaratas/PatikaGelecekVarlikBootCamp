using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    /// <summary>
    /// iş katmanı
    /// burada yapılacak işleri direk verdiğimiz kısım api tarafındaki controller'lardan direk burası ile çalışırız bu da ilgili işi yapmak için diğer katmanlara başvurur
    /// SOLID presiplerinden S harfi (single of responsibility - Tek sorumluluk ilkesi)katı bir şekilde geçerlidir. Bir method bir iş  yapar. 
    /// if suistimali yapılmamalıdır. 
    /// User ile ilgili Ekleme Silme Güncelleme Listeleme VB. DataAccess ile iletişim kurar ve gerçekleştirir.
    /// </summary>
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            user.Idatetime = DateTime.UtcNow;
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<User> Get(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListed);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var test = _userDal.Get(u => u.Email == email);
            if (email!=null&& test!=null)
            {
               
                return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
            }
            return new ErrorDataResult<User>();

            

            
          
        }

        

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
