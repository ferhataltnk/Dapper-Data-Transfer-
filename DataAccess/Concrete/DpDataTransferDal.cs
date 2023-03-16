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
using System.Data;
using Core.Utilities.Result;

namespace DataAccess.Concrete
{
    public class DpDataTransferDal : IDataTransferDal
    {

        public async Task<IResult> FromDbToDbTransferDataTable()
        {
            try
            {

                using (var connection = new SqlConnection(ConnectionStrings.urunsDbConnectionString))
                {
                    DpProductDal productDal = new DpProductDal();
                    var productNamesDataTable = productDal.GetProductNamesDataTable().Data;
                    
                    await connection.OpenAsync();
             
                    await connection.ExecuteAsync(Queries.QUERY_TEMP_CREATE_TEMP_TABLE);


                    using (SqlBulkCopy sqlBulkCopy = new(connection))
                    {
                        sqlBulkCopy.DestinationTableName = "[dbo].[#TEMP]";
                        sqlBulkCopy.BulkCopyTimeout = 0;
                        productNamesDataTable.Columns.Cast<DataColumn>().ToList().ForEach(p => sqlBulkCopy.ColumnMappings.Add(p.ColumnName, destinationColumn: p.ColumnName));
                        await sqlBulkCopy.WriteToServerAsync(productNamesDataTable);

                    }

                    await connection.ExecuteAsync(Queries.QUERY_URUNS_TEMP_TO_URUN_INSERT);

                    await connection.ExecuteAsync(Queries.QUERY_TEMP_DROP_TEMP_TABLE);

                    await connection.CloseAsync();


                    return new Result(success: true, message: "Transfer başarıyla gerçekleştirildi.");
                }
            }
            catch (Exception e)
            {

                return new Result(success: true, message: $"Transfer işlemi sırasında bir hata oluştu. \n Detay: {e.Message}");

            }

        }
    }

}
