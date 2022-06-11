using example2.DataAccessLayer.Concrete.EntityFrameWork;
using Microsoft.EntityFrameworkCore;

namespace example2
{
    public static class DataSeeding
    {
        public static void Seed(DbContext context){
            if (context.Database.GetPendingMigrations().Count() ==0)
            {
                if (context is ShopContext)
                {
                    ShopContext _context = context as ShopContext;
                }
            }
        }
    }
}