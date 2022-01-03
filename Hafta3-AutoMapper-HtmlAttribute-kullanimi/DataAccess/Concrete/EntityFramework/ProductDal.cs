using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    /// <summary>
    /// data erişim katmanı
    /// EfEntityReposityoryBase Veritabanı işlemleri için base class oluyor
    /// core katmanındaki  IEntityRepository<T> aynı operasyonel  işlemleri base olarak tutuyor ilgili dal katmanının interface ekleniyor bu sayede aynı işlemleri tekrar tekrar imzalamıyoruz
    ///  
    /// </summary>
    public class ProductDal:EfEntityRepositoryBase<Product,GrootContext>,IProductDal
    {
    }
}
