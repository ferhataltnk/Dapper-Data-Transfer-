using Core.Utilities.Result;
using Dapper;
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
                var products = connection.Query<Product>(Queries.QUERY_PRODUCTS_SELECT_PRODUCTS);
                //foreach (var product in products)
                //{
                //    Console.WriteLine("Urun ismi:" + product.productName + " Urun Id:" + product.productId + " Price:" + product.Price);
                //}
                connection.Close();
                return products.ToList();
            }
        }
   



        #region GetProductDataTable
        public IDataResult<DataTable> GetProductsDataTable()
        {
            try
            {
                var result = new DataResult<DataTable>(new DataTable(), true, $"Tablo bilgisine ait veriler başarılı bir şekilde listelendi.");

                using (var connection = new SqlConnection(ConnectionStrings.productsDbConnectionString))
                {
                    connection.Open();
                    IDataReader dataReader = connection.ExecuteReader(sql: Queries.QUERY_PRODUCTS_SELECT_PRODUCTS,commandTimeout: 0);
                    result.Data.Load(dataReader);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                return new DataResult<DataTable> (null,false, $"Tablo bilgisine ait veriler sorgulanırken beklenmedik bir hata oluştu.{e.Message} ");
            }
              
            }

        #endregion






        #region GetProductDataTable
        public IDataResult<DataTable> GetProductNamesDataTable()
        {
            try
            {
                var result = new DataResult<DataTable>(new DataTable(), true, $"Tablo bilgisine ait veriler başarılı bir şekilde listelendi.");

                using (var connection = new SqlConnection(ConnectionStrings.productsDbConnectionString))
                {
                    connection.Open();
                    IDataReader dataReader = connection.ExecuteReader(sql: Queries.QUERY_PRODUCTS_SELECT_PRODUCT_NAMES, commandTimeout: 0);
                    result.Data.Load(dataReader);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                return new DataResult<DataTable>(null, false, $"Tablo bilgisine ait veriler sorgulanırken beklenmedik bir hata oluştu.{e.Message} ");
            }

        }

        #endregion
    }


}

