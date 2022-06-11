using example2.DataAccessLayer.Abstract;
using example2.Entities.Concrete;

namespace example2.DataAccessLayer.Concrete.EntityFrameWork
{
    public class EfProdcutDal : IProductDal
    {
        public void AddProducts(){
            using (var db = new ShopContext())
            {
                var products = new List<Product>();

                products.Add(new Product{ProductName = "Samsung S8",ProdcutPrice = 4500});
                products.Add(new Product{ProductName = "Samsung S9",ProdcutPrice = 5500});
                products.Add(new Product{ProductName = "Samsung S10",ProdcutPrice = 6500});
                products.Add(new Product{ProductName = "Samsung S11",ProdcutPrice = 7500});
                db.Products.AddRange(products);
                db.SaveChanges();
            }

            Console.WriteLine("Data has been added...");

        }

        public void AddProduct(){
            using (var db = new ShopContext())
            {
                var p =new Product{ProductName = "Samsung S8",ProdcutPrice = 4500};

                db.Products.Add(p);
                db.SaveChanges();
            }
            Console.WriteLine("Data has been added...");
        }

        public void GetAllProducts(){
            using (var db = new ShopContext())
            {
                var products = db.Products.ToList();

                foreach (var item in products)
                {
                Console.WriteLine("Name: " + item.ProductName +" Id: " +  item.ProductId + " Price: " + item.ProdcutPrice);
                }
            }           
        }
        public void GetProductById(int Id){
            using (var db = new ShopContext())
            {
                var product = db.Products.Where(p => p.ProductId == Id).FirstOrDefault();

                Console.WriteLine("Name: " + product.ProductName + " Id: " + product.ProductId + "Price: " + product.ProdcutPrice);
            }   
        }

        public void GetProductByName(string Name)
        {
            using (var db = new ShopContext())
            {
                var products = db.Products.Where(p => p.ProductName.ToLower().Contains(Name.ToLower())).ToList();

                foreach (var item in products)
                {
                    Console.WriteLine("Name: " + item.ProductName + " Id: " + item.ProductId + "Price: " + item.ProdcutPrice);
                }
                
            }
        }

        public void UpdateProductById(int Id)
        {
            using (var db = new ShopContext())
            {
                var product = db.Products.Where(p => p.ProductId == Id).FirstOrDefault();

                if(product != null){
                    Console.WriteLine("Old Price: " + product.ProdcutPrice);
                    product.ProdcutPrice *= (decimal)1.2;
                    Console.WriteLine("Product Updated!!");
                    Console.WriteLine("New Price: " + product.ProdcutPrice);
                }else{
                    Console.WriteLine("There is no Product with this id: " + Id);
                }
                db.SaveChanges();
            }
        }

        public void DeleteProductById(int Id)
        {
            using (var db = new ShopContext())
            {
                var product = db.Products.Where(p => p.ProductId == Id).FirstOrDefault();

                if(product != null){
                    db.Remove(product);
                    db.SaveChanges();

                    Console.WriteLine("Product Deleted!!!");
                }else{
                    Console.WriteLine("There is no Product with this ID: ");
                }
            }
        }

        public void InsertUsers()
        {
            var users = new List<User>(){
                new User{Name = "Tolga Ozkan", Email = "tolgasukruozkan@gmail.com"},
                new User{Name = "alsfösaf Ozkan", Email = "adadsadsad@gmail.com"},
                new User{Name = "asdsadsad Ozkan", Email = "yıouyıu@gmail.com"},
                new User{Name = "Tolaadsad Ozkan", Email = "dfgfdgfdgfd@gmail.com"}
            };

            using (var db = new ShopContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
                Console.WriteLine("Users has been added!!!");
            }
        }

        public void InsertAddresses()
        {
            var addresses = new List<Address>(){
                new Address{FullName = "Tolga Ozkan" , Title = "Home" , Body = "Ankara",UserId = 1},
                new Address{FullName = "Baran Sonmez" , Title = "Work" , Body = "Isparta",UserId = 2},
                new Address{FullName = "Batuhan Sahin" , Title = "School" , Body = "Ankara",UserId = 3},
                new Address{FullName = "Hasan Eke" , Title = "Home" , Body = "Hatay",UserId = 4},
            };

            using (var db = new ShopContext())
            {
                db.Addresses.AddRange(addresses);
                db.SaveChanges();
                Console.WriteLine("Addresses has been added");
            }
        }

        public void InsertCustomers()
        {
            var customers = new List<Customer>(){
                new Customer{IdentityNumber = 11111,FirstName = "Tolga", LastName = "Ozkan" , UserId = 1},
                new Customer{IdentityNumber = 22222,FirstName = "Efe", LastName = "Ba" , UserId = 2},
                new Customer{IdentityNumber = 33333,FirstName = "Baran", LastName = "Sonmez" , UserId = 4},
                new Customer{IdentityNumber = 44444,FirstName = "Batuhan", LastName = "Sahin" , UserId = 3},
                
            };

            using (var db = new ShopContext())
            {
                db.Customers.AddRange(customers);
                db.SaveChanges();
                Console.WriteLine("Customers has been added");
            }
        }
    }
}