using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
namespace SINHA.MEDLAR.ERP.BLL
{
    public class POTypeBLL
    {
        public string savePOTypeInformation(POTypeDTO objPOTypeDTO)
        {

            POTypeDAL objPOTypeDAL = new POTypeDAL();
            string strMsg = "";


            strMsg = objPOTypeDAL.savePOTypeInformation(objPOTypeDTO);
            return strMsg;


        }


    }
}
