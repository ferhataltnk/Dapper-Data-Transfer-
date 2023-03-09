using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
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

        public IDataResult<List<Product>> GetProducts()
        {
            try
            {
                var products = _productDal.GetProducts();
                return new SuccessDataResult<List<Product>>(products, "Productlar başarıyla getirildi.");

            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Product>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Productlar getirilirken beklenmeyen bir sonuçla karşılaşıldı. Detay:{ex.Message}"
                };
            }
        }


    }
}
