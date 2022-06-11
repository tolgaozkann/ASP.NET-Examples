using example2.Entities.Abstract;

namespace example2.Entities.Concrete
{
    public class ProductCategory :IEntities
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}