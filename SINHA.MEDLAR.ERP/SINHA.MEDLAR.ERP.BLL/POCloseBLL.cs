using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class POCloseBLL
    {

        public string addPOCloseInfo(POCloseDTO objPOCloseDTO)
        {

            POCloseDAL objPOCloseDAL = new POCloseDAL();
            string strMsg = objPOCloseDAL.addPOCloseInfo(objPOCloseDTO);
            return strMsg;
        }

        public DataTable searchBuyerInfoFromPOMain(POCloseDTO objPOCloseDTO)
        {

            DataTable dt = new DataTable();
            POCloseDAL objPOCloseDAL = new POCloseDAL();


            dt = objPOCloseDAL.searchBuyerInfoFromPOMain(objPOCloseDTO);
            return dt;

        }


        public DataTable loadPOCloseRecord(string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {

            POCloseDTO objPOCloseDTO = new POCloseDTO();
            POCloseDAL objPOClosepDAL = new POCloseDAL();
            DataTable dt = new DataTable();

            dt = objPOClosepDAL.loadPOCloseRecord(strBuyerId,strHeadOfficeId, strBranchOfficeId);
            return dt;


        }

        public string deletePOCloseRecord(POCloseDTO objPOCloseDTO)
        {

            POCloseDAL objPOCloseDAL = new POCloseDAL();
            string strMsg = objPOCloseDAL.deletePOCloseRecord(objPOCloseDTO);
            return strMsg;
        }




    }
}
