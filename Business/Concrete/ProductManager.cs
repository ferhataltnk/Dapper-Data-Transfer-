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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<DataTable> GetProductDataTable()
        {
            try
            {
                var products = _productDal.GetProductsDataTable();
                return new DataResult<DataTable>(data:products.Data,success:true ,message:"Productlar başarıyla getirildi.");

            }
            catch (Exception ex)
            {

                return new DataResult<DataTable>
                (
                    data : null,
                    success : false,
                    message : $"Productlar getirilirken beklenmeyen bir sonuçla karşılaşıldı. Detay:{ex.Message}"
                );
            }
        }




      


        public IDataResult<DataTable> GetProductNameDataTable()
        {
            try
            {
                var productNames = _productDal.GetProductNamesDataTable();
                return new SuccessDataResult<DataTable>(productNames.Data, $"Tablo bilgisine ait veriler başarılı bir şekilde listelendi.");
            }
            catch (Exception e)
            {
                return new ErrorDataResult<DataTable>(null, $"Tablo bilgisine ait veriler sorgulanırken beklenmedik bir hata oluştu.Detay: {e.Message} ");

            }
        }
    }
}
