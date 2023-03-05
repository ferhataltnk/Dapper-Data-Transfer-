using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace DataAccess.Concrete
{
    public class DpDataTransferDal : IDataTransferDal
    {
        public void FromDbToDbTransfer() { 
         using (var connection = new SqlConnection(ConnectionStrings.productsDbConnectionString))
            {
                connection.Open();
                connection.Execute(Queries.q_ProductsTableToTempTable);
                connection.Execute(Queries.q_UseUrunsDb);
                int count =connection.Execute(Queries.q_TempTableToUrunsTable);
                connection.Execute(Queries.q_dropTempTable);
                connection.Close();
                Console.WriteLine(count+" ürün tabloya eklendi");
            }
            
         } 
    }
}
