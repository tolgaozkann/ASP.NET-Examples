namespace example1
{
    public interface IProductDal
    {
         List<Product> GetAll();
         List<Product> Find(string Name);
         int Add(Product p);
         int Update(Product p);
         int Delete(int ProductId);
         Product GetProductById(int id);
         int Count();
    }
}