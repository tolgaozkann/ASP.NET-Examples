using System.Data.SqlClient;

namespace example1.DataAccessLayer.Concrete
{
    public class MsSqlProductDal : IProductDal
    {

        private  SqlConnection GetMsSqlConnection(){
            string connectionString = @"Data Source = .\SQLEXPRESS; Initial Catalog = Northwind; Integrated Security= SSPI";
            return new SqlConnection(connectionString);
            
        }
        public int Add(Product p)
        {
            int result = 0;
            using (var connection = GetMsSqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "INSERT INTO PRODUCTS (ProductName,UnitPrice,Discontinued) VALUES (@productName,@unitPrice,@discontinued)";

                    SqlCommand command = new SqlCommand(sql,connection);

                    command.Parameters.AddWithValue("@productName",p.Name);
                    command.Parameters.AddWithValue("@unitPrice",p.Price);
                    command.Parameters.AddWithValue("@discontinued",1);

                     result = command.ExecuteNonQuery();

                    Console.WriteLine($"{result} kadar eklendi");


                }
                catch (System.Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }finally{

                    connection.Close();
                }
            }
            return result;
        }

        public int Delete(int ProductId)
        {
            int result = 0;
            using (var connection = GetMsSqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "DELETE FROM PRODUCTS WHERE ProductId = @productId";

                    SqlCommand command = new SqlCommand(sql,connection);

                    command.Parameters.AddWithValue("@productId",ProductId);
                    

                     result = command.ExecuteNonQuery();

                    


                }
                catch (System.Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }finally{

                    connection.Close();
                }
            }
            return result;
        }

        public List<Product> GetAll()
        {
            List<Product> products = null;
            using (var connection = GetMsSqlConnection())
            {
                try
                {
                    connection.Open();
                    

                    string sql = "SELECT * FROM PRODUCTS";

                    SqlCommand command = new SqlCommand(sql,connection);

                    var reader = command.ExecuteReader();
                    
                     products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(reader["ProductId"].ToString()),
                            Name = reader["ProductName"].ToString(),
                            Price = Convert.ToDouble(reader["UnitPrice"]?.ToString())
                        });
                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
                finally{
                    connection.Close();
                }
            }
            return products;
        }

        public int Update(Product p)
        {
            int result = 0;
            using (var connection = GetMsSqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "UPDATE PRODUCTS SET ProductName = @productName,UnitPrice = @unitPrice where ProductId = @productId";

                    SqlCommand command = new SqlCommand(sql,connection);

                    command.Parameters.AddWithValue("@productName",p.Name);
                    command.Parameters.AddWithValue("@unitPrice",p.Price);
                    command.Parameters.AddWithValue("@productId",p.ProductId);

                     result = command.ExecuteNonQuery();

                    


                }
                catch (System.Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }finally{

                    connection.Close();
                }
            }
            return result;
        }

        public List<Product> Find(string Name)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            Product product = null;
            using (var connection = GetMsSqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "SELECT * FROM PRODUCTS WHERE ProdcutId=@productid";

                    SqlCommand command = new SqlCommand(sql,connection);

                    command.Parameters.Add("@productid",(System.Data.SqlDbType.Int),id);

                    var reader = command.ExecuteReader();

                    reader.Read();

                    
                    if(reader.HasRows){
                        Console.WriteLine("Connection");
                        product = new Product()
                        {
                            ProductId = Convert.ToInt32(reader["ProductId"].ToString()),
                            Name = reader["ProductName"].ToString(),
                            Price = Convert.ToDouble(reader["UnitPrice"]?.ToString())
                        };
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
                finally{
                    connection.Close();
                }
            }
            return product;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        
    }
}