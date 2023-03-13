using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Constats
{
    public static class Queries
    {

        /*PRODUCTS*/

        public const string QUERY_PRODUCTS_USE_PRODUCTS_DB = @"use PRODUCTS";

        public const string QUERY_PRODUCTS_SELECT_PRODUCT_NAMES = @"Select Name
                                                                    From PRODUCTS";
        public const string QUERY_PRODUCTS_SELECT_PRODUCTS = @"Select* 
                                                               From PRODUCTS
                                                               ORDER BY ProductId DESC";




        /*URUNS*/

        public const string QUERY_URUNS_SELECT_URUNS = @"Select* 
                                                         From URUNS
                                                         ORDER BY UrunId DESC";

        public const string QUERY_URUNS_SELECT_URUNS_NAMES = @"Select Adi
                                                                From URUNS";

        public const string QUERY_URUNS_DELETE_URUN_BY_ID = @"DELETE FROM URUNS WHERE UrunId = @UrunId";

        public const string QUERY_URUNS_INSERT_INTO_URUN_NAMES = @"INSERT INTO #TEMP ([Name]) VALUES (@name)";

        public const string QUERY_URUNS_TEMP_TO_URUN_INSERT = @"INSERT INTO URUNS (Adi) 
                                                                Select t.Name 
                                                                FROM #TEMP t
                                                                LEFT JOIN URUNS U
                                                                ON t.Name = U.Adi
                                                                WHERE U.Adi IS NULL";




        /*TEMP*/

        public const string QUERY_TEMP_CREATE_TEMP_TABLE = @"    CREATE TABLE #TEMP (Name varchar(30))";
        
        
        public const string QUERY_TEMP_DROP_TEMP_TABLE = @"DROP TABLE #TEMP";

    }
}
