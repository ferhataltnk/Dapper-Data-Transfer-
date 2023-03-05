using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UrunManager : IUrunService
    {

        IUrunDal urunDal;

        public UrunManager(IUrunDal urunDal)
        {
            this.urunDal = urunDal;
        }

        public List<Urun> GetUruns()
        {
           return urunDal.GetUruns();
        }

        public void DeleteUrunById(int urunId)
        {
            urunDal.DeleteUrunById(urunId);
        }
    }
}
