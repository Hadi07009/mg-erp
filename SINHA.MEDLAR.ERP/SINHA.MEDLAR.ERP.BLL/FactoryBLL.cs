using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class FactoryBLL
    {

        public string saveFactoryInformation(FactoryDTO objFactoryDTO)
        {
            FactoryDAL objFactoryDAL = new FactoryDAL();
            string strMsg = "";


            strMsg = objFactoryDAL.saveFactoryInformation(objFactoryDTO);
            return strMsg;

        }

    }
}
