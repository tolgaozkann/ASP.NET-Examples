using example2.Entities.Abstract;

namespace example2.Entities.Concrete
{
    public class Customer : IEntities
    {
        public int Id { get; set; }
        public int IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}