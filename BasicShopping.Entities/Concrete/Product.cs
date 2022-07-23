using BasicShopping.Entities.Abstract;

namespace BasicShopping.Entities.Concrete
{
    public class Product : MongoDbEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; } 
    }
}
