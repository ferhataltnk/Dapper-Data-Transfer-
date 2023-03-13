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


        
        public IResult FromDbToDbTransfer()
        {
            
            try
            {
                
              var result= _dataTransferDal.FromDbToDbTransferDataTable();
                return new Result(success:true, message:"Transfer başarıyla tamamlandı.");  
            }
            catch (Exception e)
            {

                return new Result(success:false, message:$"Beklenmedik bir hata oluştu. \n Detay: {e.Message}");
            }

        }

    }
}
