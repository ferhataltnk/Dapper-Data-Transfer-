using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TransferData.ViewComponents.urunTable
{
    public class UrunTable : ViewComponent
    {
        private readonly IUrunService _urunService;

        public UrunTable(IUrunService urunService)
        {
            _urunService = urunService;
        }

        public IViewComponentResult Invoke()
        {
            var urunList = _urunService.GetUruns().Data;

            return View(urunList);
        }
    }
}
