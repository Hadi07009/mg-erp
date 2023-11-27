using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class POEntryBLL
    {

        public string savePOEntryInfo(POEntryDTO objPOEntryDTO)
        {

            POEntryDAL objPOEntryDAL = new POEntryDAL();
            string strMsg = objPOEntryDAL.savePOEntryInfo(objPOEntryDTO);
            return strMsg;
        }
        public string deletePoEntryRecord(POEntryDTO objPOEntryDTO)
        {

            POEntryDAL objPOEntryDAL = new POEntryDAL();
            string strMsg = objPOEntryDAL.deletePoEntryRecord(objPOEntryDTO);
            return strMsg;
        }
        public string deletePoEntrySubRecord(POEntryDTO objPOEntryDTO)
        {

            POEntryDAL objPOEntryDAL = new POEntryDAL();
            string strMsg = objPOEntryDAL.deletePoEntrySubRecord(objPOEntryDTO);
            return strMsg;
        }
        public DataTable LoadPOEntryInfoSub(POEntryDTO objPOEntryDTO)
        {

            DataTable dt = new DataTable();
            POEntryDAL objPOEntryDAL = new POEntryDAL();


            dt = objPOEntryDAL.LoadPOEntryInfoSub(objPOEntryDTO);
            return dt;

        }

        public POEntryDTO searchPOInfoMain(string strPONo, string strHeadOfficeId, string strBranchOfficeId)
        {


            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryDAL objPOEntryDAL = new POEntryDAL();

            objPOEntryDTO = objPOEntryDAL.searchPOInfoMain(strPONo, strHeadOfficeId, strBranchOfficeId);

            return objPOEntryDTO;


        }


        public POEntryDTO chkPOExists(string strPONo, string strHeadOfficeId, string strBranchOfficeId)
        {


            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryDAL objPOEntryDAL = new POEntryDAL();

            objPOEntryDTO = objPOEntryDAL.chkPOExists(strPONo, strHeadOfficeId, strBranchOfficeId);

            return objPOEntryDTO;


        }


        public POEntryDTO chkStyleNo(string strStyleNo,string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {


            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryDAL objPOEntryDAL = new POEntryDAL();

            objPOEntryDTO = objPOEntryDAL.chkStyleNo(strStyleNo, strBuyerId, strHeadOfficeId, strBranchOfficeId);

            return objPOEntryDTO;


        }
       
        public POEntryDTO chkColorName(string strColorFullName,string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {


            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryDAL objPOEntryDAL = new POEntryDAL();

            objPOEntryDTO = objPOEntryDAL.chkColorName(strColorFullName, strBuyerId, strHeadOfficeId, strBranchOfficeId);

            return objPOEntryDTO;


        }
    }
}
