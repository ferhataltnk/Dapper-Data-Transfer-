using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data,string message) : base(data, true, message)
        {
        }

        public SuccessDataResult(T data) : base(data,true)
        {
                
        }


        #region Çok kullanılmaya kısım
        //Değer döndürmeden sadece işlemin başarılı olduğunu bildirir ve mesaj gönderir.
        public SuccessDataResult(string message) : base(default, true,message)
        {

        }


        //Mesaj ya da değer döndürmeden sadece işlemin başarılı olduğunu bildirir.
        public SuccessDataResult( ) : base(default, true)
        {

        }

        #endregion

    }
}
