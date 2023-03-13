using Core.Utilities.Result;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUrunService
    {
        public IDataResult<DataTable> GetUruns();

        public IResult DeleteUrunById(int urunId);

    }
}
