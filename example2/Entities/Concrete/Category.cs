using System.ComponentModel.DataAnnotations;
using example2.Entities.Abstract;

namespace example2.Entities.Concrete
{
    public class Category:IEntities
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ?CategoryName { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}