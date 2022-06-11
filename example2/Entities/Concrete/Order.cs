using System;
using example2.Entities.Abstract;

namespace example2.Entities.Concrete
{
    public class Order:IEntities
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateAdded { get; set; }

    }
}