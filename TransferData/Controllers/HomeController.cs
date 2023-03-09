using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Result;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TransferData.Models;

namespace TransferData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IDataTransferService _dataTransferService;
        private readonly IUrunService _urunService;


        public HomeController(IProductService productService, ILogger<HomeController> logger, IUrunService urunService, IDataTransferService dataTransferService)
        {
            _productService = productService;
            _logger = logger;
            _urunService = urunService;
            _dataTransferService = dataTransferService;
        }



        public IActionResult Index()
        {

            var products = _productService.GetProducts();
            _logger.LogInformation(products.Message);
            var uruns = _urunService.GetUruns();
            _logger.LogInformation(uruns.Message);

            return View(); //araştır IActionResult
        }

        #region DbToDb

        public IActionResult DbToDb()
        {

            var result = _dataTransferService.FromDbToDbTransfer();

            _logger.LogInformation(result.Message);

            return RedirectToAction("Index", "Home"); //araştır
        }
        #endregion

        public IActionResult DeleteUrunById(int urunId)
        {
            var result = _urunService.DeleteUrunById(urunId);
            _logger.LogInformation(result.Message);
            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}