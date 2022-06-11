namespace example2.DataAccessLayer.Abstract
{
    public interface IProductDal
    {
         public void AddProducts();
         public void AddProduct();
         public void GetAllProducts();
         public void GetProductById(int Id);
         public void GetProductByName(string Name);
         public void UpdateProductById(int Id);
         public void DeleteProductById(int Id);
         public void InsertUsers();
         public void InsertAddresses();
         public void InsertCustomers();
    }
}