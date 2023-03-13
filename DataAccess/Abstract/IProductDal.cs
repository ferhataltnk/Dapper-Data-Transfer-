using Core.Utilities.Result;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        public IDataResult<DataTable> GetProductsDataTable();
        public IDataResult<DataTable> GetProductNamesDataTable();
    }
}
