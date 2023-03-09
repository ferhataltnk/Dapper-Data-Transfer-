using Dapper;
using DataAccess.Abstract;
using DataAccess.Constats;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class DpUrunDal : IUrunDal
    {

        public List<Urun> GetUruns()
        {
            using (var connection = new SqlConnection(ConnectionStrings.urunsDbConnectionString))
            {
                connection.Open();
                var uruns = connection.Query<Urun>(Queries.q_selectUruns);


                //foreach (var urun in uruns)
                //{
                //    Console.WriteLine("Urun ismi:" + urun.urunName +" UrunId:" + urun.urunId);
                //}

                connection.Close();
                return uruns.ToList();
            }

        }



        public void DeleteUrunById(int urunId)
        {
            using (var connection = new SqlConnection(ConnectionStrings.urunsDbConnectionString))
            {
                try
                {
                    connection.Open();
                    connection.Execute(Queries.q_deleteUrunsById, new { urunId = urunId });
                    connection.Close();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
    }
}
