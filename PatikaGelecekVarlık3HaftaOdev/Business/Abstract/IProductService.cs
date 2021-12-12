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
        IDataResult<List<ProductModel>> GetAll();
        IDataResult<Product> Get(int id);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
    }
}
