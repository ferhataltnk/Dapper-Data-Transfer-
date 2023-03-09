
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TransferData.ViewComponents.productTable
{
    public class ProductTable : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductTable(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var productList = _productService.GetProducts().Data;

            return View(productList);
        }
    }
}
