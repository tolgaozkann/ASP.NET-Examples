using example2.Entities.Abstract;

namespace example2.Entities.Concrete
{
    public class Supplier : IEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }   
    }
}