using BasicShopping.Entities.Concrete;
using System.Linq.Expressions;

namespace BasicShopping.Business.Abstract
{
    public interface IProductService
    {
        Task<Product> AddAsync(Product entity);
        IQueryable<Product> Get(Expression<Func<Product, bool>> predicate = null);
        Task<Product> GetByIdAsync(string id);

    }
}
