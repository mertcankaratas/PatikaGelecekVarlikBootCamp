using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Infrastructer
{
    public class MappingProfile : Profile
    {/// <summary>
    /// Mapping bağlantılarının yapıldığı yer
    /// </summary>
        public MappingProfile()
        {
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();

            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();

            //product'ta bulunan değeri product model ile map edip product dönüş değerinde  price değerinin sonuna TL eklendi
            CreateMap<Product, ProductModel>()
                .ForMember(x => x.Price, opt => opt.MapFrom(y => $"{ y.Price} TL")).ToString();
            CreateMap<ProductModel, Product>();
          


        }
    }
}
