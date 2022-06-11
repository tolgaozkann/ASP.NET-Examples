using System;
using example2.DataAccessLayer.Concrete.EntityFrameWork;
using example2.Entities.Concrete;
using example2.Entities.Northwind;

namespace example2{
    class Program{
        public static void Main(string[] args){

            using (var db = new NorthwindContext())
            {
                var products = db.Products.ToList();

                foreach (var item in products)
                {
                    Console.WriteLine("Name: " + item.ProductName + " -----------Id: " + item.ProductId);
                }
            }



            
        }
    }
}