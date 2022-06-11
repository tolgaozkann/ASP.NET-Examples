using MySql.Data.MySqlClient;

namespace example1.DataAccessLayer.Concrete
{
    public class MySqlProductDal : IProductDal
    {
        private  MySqlConnection GetMySqlConnection(){
            string connectionString = @"server=127.0.0.1;port=3306;database=northwind;user=root;password=batuhan31";


             return new MySqlConnection(connectionString);
            
        }
        public int Add(Product p)
        {
            throw new NotImplementedException();
        }

        public int Delete(int ProductId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            List<Product> products = null;
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "SELECT * FROM PRODUCTS";

                    MySqlCommand command = new MySqlCommand(sql,connection);

                    var reader = command.ExecuteReader();
                    products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(reader["id"].ToString()),
                            Name = reader["product_name"].ToString(),
                            Price = Convert.ToDouble(reader["list_price"]?.ToString())
                        });
                        //Console.WriteLine($"name: {reader[3]} price: {reader[6]}");
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
            throw new NotImplementedException();
        }

        public List<Product> Find(string Name)
        {
            List<Product> products = null;
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "SELECT * FROM PRODUCTS WHERE product_name LIKE @productName";

                    MySqlCommand command = new MySqlCommand(sql,connection);

                    command.Parameters.Add("@productName",MySqlDbType.String).Value = '%' +Name + '%';

                    var reader = command.ExecuteReader();
                    products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(reader["id"].ToString()),
                            Name = reader["product_name"].ToString(),
                            Price = Convert.ToDouble(reader["list_price"]?.ToString())
                        });
                    }

                    if (reader.HasRows)
                    {
                        
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

        public Product GetProductById(int id)
        {
            Product product = null;
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "SELECT * FROM PRODUCTS WHERE id=@productid";

                    MySqlCommand command = new MySqlCommand(sql,connection);

                    command.Parameters.Add("@productid",MySqlDbType.Int32).Value = id;

                    MySqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    Console.WriteLine("Connection");

                    if (reader.HasRows)
                    {
                        Console.WriteLine("Connection2");
                        product = new Product()
                        {
                            ProductId = Convert.ToInt32(reader["id"].ToString()),
                            Name = reader["product_name"].ToString(),
                            Price = Convert.ToDouble(reader["list_price"]?.ToString())
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
            int count = 0;
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    connection.Open();

                    string sql = "SELECT COUNT(*) FROM PRODUCTS";

                    MySqlCommand command = new MySqlCommand(sql,connection);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        count = Convert.ToInt32(result.ToString());
                    }
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
                finally{
                    connection.Close();
                }
            }
            return count;
        }

        int IProductDal.Add(Product p)
        {
            throw new NotImplementedException();
        }
    }
}