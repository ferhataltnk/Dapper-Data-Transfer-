


using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;

namespace ConsolTest
{
    public class Program
    {
        
          static void Main(string[] args)
        {
            //DataTransferManager dataTransferManager = new DataTransferManager(new DpDataTransferDal());
            //dataTransferManager.FromDbToDbTransfer();

            //ProductManager productManager = new ProductManager(new DpProductDal());
            //var products =productManager.GetProducts();
            //Console.WriteLine("---");

            UrunManager urunManager = new UrunManager(new DpUrunDal());
           
            //var uruns = urunManager.GetUruns();

           // urunManager.DeleteUrunById(25);

        }
    }
}