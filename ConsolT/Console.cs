


using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using System.Data;
using System.Data.SqlClient;

namespace ConsolT
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

            //DpProductDal pDal = new DpProductDal();
            //var a = pDal.GetProductsDataTable().Data;


            //DataRow aRow = a.Rows[0];

            //foreach (var item in aRow.ItemArray)
            //{
            //    System.Console.WriteLine(item);
            //}


            ProductManager productManager = new ProductManager(new DpProductDal());
            var productNames = productManager.GetProductNameDataTable().Data;

            //foreach (DataRow productName in productNames.Rows) {
            //    foreach (var item in productName.ItemArray)
            //    {
            //        System.Console.WriteLine(item);

            //    }
            //}

            productNames.Columns.Cast<DataColumn>().ToList().ForEach(p => System.Console.WriteLine(p));
            



        }
    }
}