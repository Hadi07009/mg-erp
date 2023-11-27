using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class TrimsDetailsBLL
    {
        public string saveTrimsDetailsInfo(TrimsDetailsDTO objTrimsDetailsDTO)
        {

            TrimsDetailsDAL objTrimsDetailsDAL = new TrimsDetailsDAL();
            string strMsg = objTrimsDetailsDAL.saveTrimsDetailsInfo(objTrimsDetailsDTO);
            return strMsg;
        }
        public DataTable searchTrimsDetailsRecord(TrimsDetailsDTO objTrimsDetailsDTO)
        {

            DataTable dt = new DataTable();
            TrimsDetailsDAL objTrimsDetailsDAL = new TrimsDetailsDAL();


            dt = objTrimsDetailsDAL.searchTrimsDetailsRecord(objTrimsDetailsDTO);
            return dt;

        }
        public TrimsDetailsDTO searchTrimsDetailsRecordMain(string strContactNo, string strPONo, string strStyleNo, string strFobDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            TrimsDetailsDTO objTrimsDetailsDTO = new TrimsDetailsDTO();
            TrimsDetailsDAL objTrimsDetailsDAL = new TrimsDetailsDAL();

            objTrimsDetailsDTO = objTrimsDetailsDAL.searchTrimsDetailsRecordMain(strContactNo, strPONo, strStyleNo, strFobDate, strHeadOfficeId, strBranchOfficeId);

            return objTrimsDetailsDTO;


        }
        public TrimsDetailsDTO getFobDateAndOrderQty(TrimsDetailsDTO objTrimsDetailsDTO )
        {


           
            TrimsDetailsDAL objTrimsDetailsDAL = new TrimsDetailsDAL();

            objTrimsDetailsDTO = objTrimsDetailsDAL.getFobDateAndOrderQty(objTrimsDetailsDTO);

            return objTrimsDetailsDTO;


        }
    }
}
