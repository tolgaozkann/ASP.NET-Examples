using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using example1.BusinessLayer.Concrete;
using example1.DataAccessLayer.Concrete;
using MySql.Data.MySqlClient;


namespace example1{
    public class Program{
        public static void Main(string[] args){

            var productManager = new ProductManager(new MsSqlProductDal());

            

            var p = new Product(){
                ProductId = 78,
                Name = "Samsung S7",
                Price = 5000
            };


            var result = productManager.Delete(p.ProductId);


            


            Console.WriteLine($"{result}");
                
        }
    }
}
