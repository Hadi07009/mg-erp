using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class ColorBLL
    {

        public string saveColorInformation(ColorDTO objColorDTO)
        {
            ColorDAL objColorDAL = new ColorDAL();
            string strMsg = "";

            strMsg = objColorDAL.saveColorInformation(objColorDTO);
            return strMsg;

        }
        public string saveColorContractInfo(ColorDTO objColorDTO)
        {
            ColorDAL objColorDAL = new ColorDAL();
            string strMsg = "";

            strMsg = objColorDAL.saveColorContractInfo(objColorDTO);
            return strMsg;

        }





    }
}
