using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class ForgetPassBLL
    {
        public string sendeEmployeePass(string strFromEmail)
        {
            ForgetPassDTO objForgetPassDTO = new ForgetPassDTO();
            ForgetPassDAL objForgetPassDAL = new ForgetPassDAL();

            string strMsg = objForgetPassDAL.sendeEmployeePass(strFromEmail);
            return strMsg;

        }


    }
}
