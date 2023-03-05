using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TransferData.ViewComponents.urunTable
{
    public class UrunTable:ViewComponent
    {
        IUrunService urunService;

        public UrunTable(IUrunService urunService)
        {
            this.urunService = urunService;
        }

        public IViewComponentResult Invoke()
        {
            var urunList = urunService.GetUruns();

            return View(urunList);
        }
    }
}
