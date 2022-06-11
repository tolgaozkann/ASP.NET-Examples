using System.ComponentModel.DataAnnotations;
using example2.Entities.Abstract;

namespace example2.Entities.Concrete
{
    public class Product : IEntities
    {
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ?ProductName { get; set; }
        public decimal ProdcutPrice { get; set; }
        public string Description { get; set;}
        public int Category_Id { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}