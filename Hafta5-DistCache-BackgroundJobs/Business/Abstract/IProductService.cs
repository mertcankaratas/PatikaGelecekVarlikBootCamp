using Core.Utilities.Results;
using Entities.Concrete;
using Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        //IDataResult<List<ProductModel>> GetAll();
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllPaged(int pageNumber,int elementcount);
        IDataResult<List<Product>> GetAllPagedFilteringSortingAsc(int pageNumber,int elementcount,string name);
        IDataResult<List<Product>> GetAllPagedFilteringSortingDesc(int pageNumber,int elementcount,string name);

        IDataResult<List<Product>> GetAllSortedAsc();
        IDataResult<List<Product>> GetAllSortedDesc();
        IDataResult<List<Product>> GetAllFiltered(string name);
        IDataResult<Product> Get(int id);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
    }
}
