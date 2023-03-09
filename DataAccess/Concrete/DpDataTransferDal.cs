using DataAccess.Abstract;
using DataAccess.Constats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Entities;

namespace DataAccess.Concrete
{
    public class DpDataTransferDal : IDataTransferDal
    {


        public void FromDbToDbTransfer()
        {
            using (var connection = new SqlConnection(ConnectionStrings.productsDbConnectionString))
            {
                connection.Open();
                connection.Execute(Queries.q_ProductsTableToTempTable);
                connection.Execute(Queries.q_UseUrunsDb);
                int count = connection.Execute(Queries.q_TempTableToUrunsTable);
                connection.Execute(Queries.q_dropTempTable);
                connection.Close();
                Console.WriteLine(count + " ürün tabloya eklendi");
            }

        }


        public void FromDbToDbTransferV2()
        {
            using (var connection = new SqlConnection(ConnectionStrings.urunsDbConnectionString))
            {
                DpProductDal productDal = new DpProductDal();
                var productNames = productDal.GetProductNames().ToList();
                connection.Open();
                //  var productNames = connection.Query<string>(Queries.q_selectProductNames);
                connection.Execute(Queries.q_createTempTableV2);

                foreach (var item in productNames)
                {
                    connection.Execute(Queries.q_insertIntoUrunNamesV2,
                    new[]
                    {
                        new{name=item},

                    });
                }


                connection.Execute(Queries.q_TempTableToUrunsTableV2);

                connection.Execute(Queries.q_dropTempTableV2);


                connection.Close();
            }

        }

    }

}
