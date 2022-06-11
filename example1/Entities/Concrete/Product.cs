using example1.Entities.Abstract;

namespace example1
{
    public class Product : IEntities
    {
        public int ProductId { get; set; }
        public string ?Name { get; set; }
        public double Price { get; set; }
    }
}