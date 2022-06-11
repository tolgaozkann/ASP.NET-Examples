namespace example1.BusinessLayer.Concrete
{
    public class ProductManager : IProductDal
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal){
            _productDal = productDal;
        }
        public int Add(Product p)
        {
            return _productDal.Add(p);
        }

        public int Count()
        {
            return _productDal.Count();
        }

        public int Delete(int ProductId)
        {
            return _productDal.Delete(ProductId);
        }

        public List<Product> Find(string Name)
        {
            return _productDal.Find(Name);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _productDal.GetProductById(id);
        }

        public int Update(Product p)
        {
            return _productDal.Update(p);
        }

        
    }
}