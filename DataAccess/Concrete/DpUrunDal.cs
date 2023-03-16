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
    public class DpUrunDal : IUrunDal
    {

        public IDataResult<DataTable> GetUruns()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionStrings.urunsDbConnectionString))
                {
                    var result = new DataResult<DataTable>(data: new DataTable(), success: true, message: "Ürünler başarılı bir şekilde listelendi.");
                    connection.Open();
                    IDataReader uruns = connection.ExecuteReader(Queries.QUERY_URUNS_SELECT_URUNS);
                    
                    result.Data.Load(uruns);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new DataResult<DataTable>(data: null, success: false, message: $"Ürünler getirilirken bir hata oluştu.\n Detay: {ex.Message}");
            }
            

        }



        public IResult DeleteUrunById(int urunId)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionStrings.urunsDbConnectionString))
                {


                    connection.Open();
                    connection.Execute(Queries.QUERY_URUNS_DELETE_URUN_BY_ID, new { urunId = urunId });
                    connection.Close();

                }
                return new Result(true);
            }
            catch (Exception e)
            {

                return new Result(success:false,message:$"Ürün Silinemedi.\n Detay: {e.Message}");
            }
          
        }
    }
}
