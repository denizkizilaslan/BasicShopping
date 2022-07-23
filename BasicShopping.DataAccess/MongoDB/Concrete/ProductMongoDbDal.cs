using BasicShopping.Common.Utilities.AppSettings;
using BasicShopping.DataAccess.MongoDB.Abstract;
using BasicShopping.Entities.Concrete;
using Microsoft.Extensions.Options;
namespace BasicShopping.DataAccess.MongoDB.Concrete
{
     public class ProductMongoDbDal : MongoDbRepositoryBase<Product>, IProductDal
    {
        public ProductMongoDbDal(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
