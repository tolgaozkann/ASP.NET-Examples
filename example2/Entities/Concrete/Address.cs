using example2.Entities.Abstract;

namespace example2.Entities.Concrete
{
    public class Address:IEntities
    {
        public int AddressId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}