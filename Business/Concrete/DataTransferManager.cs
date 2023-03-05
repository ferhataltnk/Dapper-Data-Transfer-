using Business.Abstract;
using Dapper;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DataTransferManager : IDataTransferService
    {
        IDataTransferDal dataTransferDal;

        public DataTransferManager(IDataTransferDal dataTransferDal)
        {
            this.dataTransferDal = dataTransferDal;
        }

        public void FromDbToDbTransfer()
        {
            dataTransferDal.FromDbToDbTransfer(); 
        }
    }
}
