
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TransferData.ViewComponents.productTable
{
    public class ProductTable:ViewComponent
    {
        IProductService productService;

        public ProductTable(IProductService productService)
        {
            this.productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var productList = productService.GetProducts();

            return View(productList);
        }
    }
}
