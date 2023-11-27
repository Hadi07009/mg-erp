using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class POOpenBLL
    {

        public string addPOOpenInfo(POOpenDTO objPOOpenDTO)
        {

            POOpenDAL objPOOpenDAL = new POOpenDAL();
            string strMsg = objPOOpenDAL.addPOOpenInfo(objPOOpenDTO);
            return strMsg;
        }

        public DataTable searchBuyerInfoFromPOMain(POOpenDTO objPOOpenDTO)
        {

            DataTable dt = new DataTable();
            POOpenDAL objPOOpenDAL = new POOpenDAL();


            dt = objPOOpenDAL.searchBuyerInfoFromPOMain(objPOOpenDTO);
            return dt;

        }


        public DataTable loadPOOpenRecord(string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {

            POOpenDTO objPOOpenDTO = new POOpenDTO();
            POOpenDAL objPOOpenpDAL = new POOpenDAL();
            DataTable dt = new DataTable();

            dt = objPOOpenpDAL.loadPOOpenRecord(strBuyerId,strHeadOfficeId, strBranchOfficeId);
            return dt;


        }

        public string deletePOOpenRecord(POOpenDTO objPOOpenDTO)
        {

            POOpenDAL objPOOpenDAL = new POOpenDAL();
            string strMsg = objPOOpenDAL.deletePOOpenRecord(objPOOpenDTO);
            return strMsg;
        }




    }
}
