﻿using Dapper;
using DataAccess.Abstract;
using DataAccess.Constats;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class DpProductDal : IProductDal
    {
        public List<Product> GetProducts()
        {
            using (var connection = new SqlConnection(ConnectionStrings.productsDbConnectionString))
            {
                connection.Open();
                var products = connection.Query<Product>(Queries.q_selectProducts);
                //foreach (var product in products)
                //{
                //    Console.WriteLine("Urun ismi:" + product.productName + " Urun Id:" + product.productId + " Price:" + product.Price);
                //}
                connection.Close();
                return products.ToList();
            }
        }





        public List<string> GetProductNames()
        {
            using (var connection = new SqlConnection(ConnectionStrings.productsDbConnectionString))
            {
                connection.Open();
                var productNames = connection.Query<string>(Queries.q_selectProductNames);
                //foreach (var product in products)
                //{
                //    Console.WriteLine("Urun ismi:" + product.productName + " Urun Id:" + product.productId + " Price:" + product.Price);
                //}
                connection.Close();
                return productNames.ToList();
            }
        }




    }
}
