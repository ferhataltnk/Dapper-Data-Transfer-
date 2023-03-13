using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UrunManager : IUrunService
    {
        private readonly IUrunDal _urunDal;
        //IUrunDal urunDal;

        public UrunManager(IUrunDal urunDal)
        {
            //this.urunDal = urunDal;
            _urunDal = urunDal;
        }

        public IDataResult<DataTable> GetUruns()
        {
            try
            {
                var uruns = _urunDal.GetUruns().Data;
                return new DataResult<DataTable>(uruns, true, "urunler getirildi");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<DataTable>
                {
                    Data = null,
                    Message = $"Ürünler getirilirken bir hata oluştu.\n Detay:{ex.Message} "
                };
            }

        }

        public IResult DeleteUrunById(int urunId)
        {
            try
            {
                //urunDal.DeleteUrunById(urunId);
                _urunDal.DeleteUrunById(urunId);
                return new SuccessResult(Messages.UrunDeleted);
            }
            catch
            {
                return new ErrorResult(Messages.UrunDeleteError);
            }


        }
    }
}

// Result class
// try catch