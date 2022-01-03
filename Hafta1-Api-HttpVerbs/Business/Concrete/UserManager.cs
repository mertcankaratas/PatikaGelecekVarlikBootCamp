using Business.Abstract;
using Core.Log;
using DataAccess.Abstract;
using Entities.Concrete;
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
    /// 
    /// </summary>
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [Make("")]
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public List<User> GetAll()
        {
            return _userDal.Getall();
        }

        public User GetById(int id)
        {
            return _userDal.Get(id);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
