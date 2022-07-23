using BasicShopping.Entities.Concrete;

namespace BasicShopping.DataAccess.MongoDB.Abstract
{
    public interface IProductDal : IRepository<Product, string>
    {
    }
}
