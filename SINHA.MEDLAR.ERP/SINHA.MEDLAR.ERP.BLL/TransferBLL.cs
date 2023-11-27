using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class TransferBLL
    {
        public DataTable loadEmployeeTransferEntry()
        {

            TransferDTO objEmployeeTransferDTO = new TransferDTO();
            TransferDAL objEmployeeTransferDAL = new TransferDAL();

            DataTable dt = new DataTable();

            dt = objEmployeeTransferDAL.loadEmployeeTransferEntry();
            return dt;

        }


        public string saveEmployeeTransfer(TransferDTO objEmployeeTransferDTO)
        {

            string strMsg = "";
            TransferDAL objEmployeeTransferDAL = new TransferDAL();

            strMsg = objEmployeeTransferDAL.saveEmployeeTransfer(objEmployeeTransferDTO);
            return strMsg;

        }

        public string employeeTransferProcess(TransferDTO objEmployeeTransferDTO)
        {

            string strMsg = "";
            TransferDAL objEmployeeTransferDAL = new TransferDAL();

            strMsg = objEmployeeTransferDAL.employeeTransferProcess(objEmployeeTransferDTO);
            return strMsg;

        }


    }
}
