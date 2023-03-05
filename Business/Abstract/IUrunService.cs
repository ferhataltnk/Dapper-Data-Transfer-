using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUrunService
    {
        public List<Urun> GetUruns();

        public void DeleteUrunById(int urunId);

    }
}
