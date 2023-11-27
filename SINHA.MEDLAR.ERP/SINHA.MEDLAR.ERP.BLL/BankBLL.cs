using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class BankBLL
    {
        public string saveBankInformation(BankDTO objBankDTO)
        {
            BankDAL objBankDAL = new BankDAL();
            string strMsg = "";


            strMsg = objBankDAL.saveBankInformation(objBankDTO);
            return strMsg;

        }

    }
}
