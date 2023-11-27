using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class LineBLL
    {
        public string saveLineInformation(LineDTO objLineDTO)
        {
            LineDAL objLineDAL = new LineDAL();
            string strMsg = "";


            strMsg = objLineDAL.saveLineInformation(objLineDTO);
            return strMsg;

        }


    }
}
