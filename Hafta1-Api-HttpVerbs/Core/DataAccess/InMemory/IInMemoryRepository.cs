using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.InMemory
{
   public interface IInMemoryRepository<T> where T: class,IEntity,new()
    {
        List<T> Getall();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
