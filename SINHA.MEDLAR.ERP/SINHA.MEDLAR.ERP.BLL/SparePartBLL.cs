using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class SparePartBLL
    {


        public string saveSparePartFile(string strSparePartId, string strFileName, byte strByte, string strEmployeeId, string strHeadOffieId, string strBranchOffieId)
        {
            string strMsg = "";
            SparePartDTO objSparePartDTO = new SparePartDTO();
            SparePartDAL objSparePartDAL = new SparePartDAL();


            strMsg = objSparePartDAL.saveSparePartFile(strSparePartId, strFileName, strByte, strEmployeeId, strHeadOffieId, strBranchOffieId);
            return strMsg;


        }

        public SparePartDTO searchSparePartsFile(string SlNo)
        {

            SparePartDTO objSparePartDTO = new SparePartDTO();
            SparePartDAL objSparePartDAL = new SparePartDAL();

            objSparePartDTO = objSparePartDAL.searchSparePartsFile(SlNo);
            return objSparePartDTO;

        }



    }
}
