using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        #region URUN MESSAGES
        public readonly static string UrunAdded = "Ürünler başarıyla eklendi";
        public readonly static string UrunDeleted = "Ürünler başarıyla silindi";
        public readonly static string UrunError = "Ürünler eklenirken bir sorun oluştu.";
        public readonly static string UrunDeleteError = "Ürün silinirken bir sorun oluştu.";
       
        #endregion
        #region DATA TRANSFER MESSAGES
        public readonly static string DataTransferSuccess = "Transfer işlemi başarılı.";
        public readonly static string DataTransferError = "Transfer işlemi başarısız.";
        #endregion
        #region PRODUCT MESSAGES
        
        #endregion
    }
}
