
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
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
                new User{Id=1,UserName="Mertcan",Email="can.mert.karatas@gmail.com",Password="a1b2c3d4e5",UserType="Admin"},
                new User{Id=2,UserName="Burak",Email="burak@gmail.com",Password="a1b2c3d4e5",UserType="User"},
                new User{Id=3,UserName="Can",Email="can@gmail.com",Password="a1b2c3d4e5",UserType="Admin"},
                new User{Id=4,UserName="Veli",Email="veli@gmail.com",Password="a1b2c3d4e5",UserType="User"},
                new User{Id=5,UserName="Ali",Email="ali@gmail.com",Password="a1b2c3d4e5",UserType="User"}
            };
        }

     
        public void Add(User entity)
        {
            _users.Add(entity);
        }

        public void Delete(User entity)
        {
            var itemRemove = _users.Where(d => d.Id == entity.Id).Any();
            var itemRemoveElement = _users.SingleOrDefault(d => d.Id == entity.Id);

            if (itemRemove)
                _users.Remove(itemRemoveElement);
        }



        public User Get(int id)
        {
            return _users.SingleOrDefault(u => u.Id == id);
        }

        public List<User> Getall()
        {
            return _users.ToList();
        }

        public void Update(User entity)
        {
            var userUpdate = _users.SingleOrDefault(u => u.Id == entity.Id);
            userUpdate.UserName = entity.UserName;
            userUpdate.Email = entity.Email;
            userUpdate.Password = entity.Password;
        }

        
    }
}
