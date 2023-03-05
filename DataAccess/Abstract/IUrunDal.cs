using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUrunDal
    {
        public List<Urun> GetUruns();
        public void DeleteUrunById(int urunId);
    }
}
