using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data) : base(data,false)
        {

        }




        #region Çok kullanılmaya kısım
        //Değer döndürmeden sadece işlemin başarılı olduğunu bildirir ve mesaj gönderir.
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }


        //Mesaj ya da değer döndürmeden sadece işlemin başarılı olduğunu bildirir.
        public ErrorDataResult() : base(default, false)
        {

        }

        #endregion
    }
}
