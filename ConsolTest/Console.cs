


using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using System.Data;
using System.Data.SqlClient;

namespace ConsolTest
{
    public class Console
    {

        static void Main(string[] args)
        {
            //DataTransferManager dataTransferManager = new DataTransferManager(new DpDataTransferDal());
            //dataTransferManager.FromDbToDbTransfer();

            //ProductManager productManager = new ProductManager(new DpProductDal());
            //var products =productManager.GetProducts();
            //Console.WriteLine("---");

            //UrunManager urunManager = new UrunManager(new DpUrunDal());

            //var uruns = urunManager.GetUruns();

            // urunManager.DeleteUrunById(25);

            DpProductDal pDal = new DpProductDal();
            var a = pDal.GetProductsDataTable().Data;


            DataRow aRow = a.Rows[0];

            //foreach (DataRow dataRow in a.Rows)
            //{
            //    foreach (var item in dataRow.ItemArray)
            //    {

            //        Console.WriteLine(item);
            //    }
            //}


        }
    }
}