using BasicShopping.Business.Abstract;
using BasicShopping.DataAccess.MongoDB.Abstract;
using BasicShopping.Entities.Concrete;
using System.Linq.Expressions;

namespace BasicShopping.Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public Task<Product> AddAsync(Product entity)
        {
            return _productDal.AddAsync(entity);
        }

        public IQueryable<Product> Get(Expression<Func<Product, bool>> predicate = null)
        {
            return _productDal.Get(predicate);
        }

        public Task<Product> GetByIdAsync(string id)
        {
            return _productDal.GetByIdAsync(id);
        }
    }
}
