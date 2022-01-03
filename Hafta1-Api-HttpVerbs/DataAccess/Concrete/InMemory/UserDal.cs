using Core.DataAccess.InMemory;

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{ 
    /// <summary>
  /// data erişim katmanı
  /// suan inmemory çalışıyoruz kendimiz birden çok  user'a sahip bir liste oluşturup onun üstünde çalışıyoruz .
  /// core katmanındaki  IInMemoryRepository<T> aynı operasyonel  işlemleri base olarak tutyor ilgili dal katmanının interface ekleniyor bu sayede aynı işlemleri tekrar tekrar imzalamıyoruz
  ///  
  /// </summary>
    public class UserDal : IUserDal
    {
        List<User> _users;
        public UserDal()
        {
            _users = new List<User>
            {
                new User{UserId=1,UserName="Mertcan",Email="can.mert.karatas@gmail.com",password="a1b2c3d4e5"},
                new User{UserId=2,UserName="Burak",Email="burak@gmail.com",password="a1b2c3d4e5"},
                new User{UserId=3,UserName="Can",Email="can@gmail.com",password="a1b2c3d4e5"},
                new User{UserId=4,UserName="Veli",Email="veli@gmail.com",password="a1b2c3d4e5"},
                new User{UserId=5,UserName="Ali",Email="ali@gmail.com",password="a1b2c3d4e5"}
            };
        }

        public void Add(User entity)
        {
            _users.Add(entity);
        }

        public void Delete(User entity)
        {
            var itemRemove = _users.Where(d => d.UserId == entity.UserId).Any();
            var itemRemoveElement = _users.SingleOrDefault(d => d.UserId == entity.UserId);

            if (itemRemove)
                _users.Remove(itemRemoveElement);
        }



        public User Get(int id)
        {
            return _users.SingleOrDefault(u => u.UserId == id);
        }

        public List<User> Getall()
        {
            return _users.ToList();
        }

        public void Update(User entity)
        {
            var userUpdate = _users.SingleOrDefault(u => u.UserId == entity.UserId);
            userUpdate.UserName = entity.UserName;
            userUpdate.Email = entity.Email;
            userUpdate.password = entity.password;
        }
    }
}
