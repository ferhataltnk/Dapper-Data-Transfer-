using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Constats
{
    public static class Queries
    {


        public const string q_ProductsTableToTempTable = @"SELECT Name INTO ##tmp FROM PRODUCTS";
        public const string q_UseUrunsDb = @"USE URUNS";
        public const string q_TempTableToUrunsTable = @"INSERT INTO URUNS (Adi) 
                                                        Select t.Name 
                                                        FROM ##tmp t
                                                        LEFT JOIN URUNS U
                                                            ON t.Name = U.Adi
                                                        WHERE U.Adi IS NULL";
        public const string q_dropTempTable = @"DROP TABLE ##tmp";
        public const string q_selectProductNames = @"Select Name
                                                 From PRODUCTS";
        public const string q_selectUrunNames = @"Select Adi
                                                 From URUNS";

        public const string q_UseProductsDb = @"use PRODUCTS";

        public const string q_selectProducts = @"Select* 
                                                 From PRODUCTS
                                                 ORDER BY ProductId DESC";
        public const string q_selectUruns = @"Select* 
                                              From URUNS
                                              ORDER BY UrunId DESC";

        public const string q_deleteUrunsById = @"DELETE FROM URUNS WHERE UrunId = @UrunId";


        public const string q_createTempTableV2 = @"    CREATE TABLE #TEMP (Name varchar(30))";
        public const string q_insertIntoUrunNamesV2 = @"INSERT INTO #TEMP ([Name]) VALUES (@name)";
        public const string q_TempTableToUrunsTableV2 = @"INSERT INTO URUNS (Adi) 
                                                        Select t.Name 
                                                        FROM #TEMP t
                                                        LEFT JOIN URUNS U
                                                            ON t.Name = U.Adi
                                                        WHERE U.Adi IS NULL";
        public const string q_dropTempTableV2 = @"DROP TABLE #TEMP";

    }
}
