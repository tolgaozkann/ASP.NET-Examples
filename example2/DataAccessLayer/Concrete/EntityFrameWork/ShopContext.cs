using example2.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace example2.DataAccessLayer.Concrete.EntityFrameWork
{
    public class ShopContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Catogeries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        /*
            Logger
        */
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => {builder.AddConsole();});

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(@"Data Source = .\SQLEXPRESS;Initial Catalog = ShopDb;Integrated Security = SSPI");
            //.UseSqlite("Data Source = shop.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<ProductCategory>()
                        .HasKey(t => new{t.ProductId,t.CategoryId});

            modelBuilder.Entity<ProductCategory>()
                        .HasOne(pc => pc.Product)
                        .WithMany(p => p.ProductCategories)
                        .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                        .HasOne(pc => pc.Category)
                        .WithMany(c => c.ProductCategories)
                        .HasForeignKey(pc => pc.CategoryId);

        }

        
    }
}