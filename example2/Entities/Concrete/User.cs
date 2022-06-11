using System.ComponentModel.DataAnnotations;
using example2.Entities.Abstract;

namespace example2.Entities.Concrete

{
    public class User:IEntities
    {
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public Customer Customer { get; set; }
        public List<Address> Addresses { get; set; }
    }
}