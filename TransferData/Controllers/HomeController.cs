using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TransferData.Models;

namespace TransferData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

    
        IProductService productService;
        IDataTransferService dataTransferService;
        IUrunService urunService;

        public HomeController(IProductService productService, ILogger<HomeController> logger, IUrunService urunService, IDataTransferService dataTransferService)
        {
            this.productService = productService;
            _logger = logger;
            this.urunService = urunService;
            this.dataTransferService = dataTransferService;
        }



        public IActionResult Index()
        {
            var products = productService.GetProducts();
            var uruns = urunService.GetUruns();
            return View();
        }


        public IActionResult DbToDb()
        {
            dataTransferService.FromDbToDbTransfer();
            return RedirectToAction("Index","Home");
        }


        public IActionResult DeleteUrunById(int urunId)
        {
            urunService.DeleteUrunById(urunId);
            return RedirectToAction("Index", "Home");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}