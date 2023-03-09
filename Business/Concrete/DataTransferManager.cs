using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
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
        private readonly IDataTransferDal _dataTransferDal;

        public DataTransferManager(IDataTransferDal dataTransferDal)
        {
            _dataTransferDal = dataTransferDal;
        }


        //Void methodları IResult türüne dönüştürdüm.
        public IResult FromDbToDbTransfer()
        {
            try
            {
                //  _dataTransferDal.FromDbToDbTransfer();
                _dataTransferDal.FromDbToDbTransferV2();
                return new SuccessResult(Messages.DataTransferSuccess);   //Constructor'a 2 parametre yolladık.
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.DataTransferError);
            }

        }


    }
}
