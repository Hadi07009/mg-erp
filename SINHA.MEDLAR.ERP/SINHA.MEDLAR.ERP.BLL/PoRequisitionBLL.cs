using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class PoRequisitionBLL
    {
        public string savePoRequisitionInfo(PoRequisitionDTO objPoRequisitionDTO)
        {

            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();
            string strMsg = objPoRequisitionDAL.savePoRequisitionInfo(objPoRequisitionDTO);
            return strMsg;
        }      

        public DataTable getPurchaseId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            PoRequisitionDAL obPoRequisitionDAL = new PoRequisitionDAL();


            dt = obPoRequisitionDAL.getPurchaseId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public PoRequisitionDTO searchPoRequisitionRecordMain(string strRequisitionNo, string strPurchaseDate, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {


            PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();

            objPoRequisitionDTO = objPoRequisitionDAL.searchPoRequisitionRecordMain(strRequisitionNo, strPurchaseDate, strSectionId, strHeadOfficeId, strBranchOfficeId);

            return objPoRequisitionDTO;


        }
        public PoRequisitionDTO getParticularname(string strPartNo, string strHeadOfficeId, string strBranchOfficeId)
        {


            PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();

            objPoRequisitionDTO = objPoRequisitionDAL.getParticularname(strPartNo, strHeadOfficeId, strBranchOfficeId);

            return objPoRequisitionDTO;


        }
        public string deletePoRequisitionRecord(PoRequisitionDTO objPoRequisitionDTO)
        {

            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();
            string strMsg = objPoRequisitionDAL.deletePoRequisitionRecord(objPoRequisitionDTO);
            return strMsg;
        }
        public string deletePoRequisitionSubRecord(PoRequisitionDTO objPoRequisitionDTO)
        {

            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();
            string strMsg = objPoRequisitionDAL.deletePoRequisitionSubRecord(objPoRequisitionDTO);
            return strMsg;
        }

        public DataTable LoadRequisitionNo(PoRequisitionDTO objPoRequisitionDTO)
        {

            DataTable dt = new DataTable();
            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();


            dt = objPoRequisitionDAL.LoadRequisitionNo(objPoRequisitionDTO);
            return dt;

        }
        public DataTable LoadPartNo(PoRequisitionDTO objPoRequisitionDTO)
        {

            DataTable dt = new DataTable();
            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();


            dt = objPoRequisitionDAL.LoadPartNo(objPoRequisitionDTO);
            return dt;

        }

        
        public DataTable LoadPoRequisitionRecordSub(PoRequisitionDTO objPoRequisitionDTO)
        {

            DataTable dt = new DataTable();
            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();


            dt = objPoRequisitionDAL.LoadPoRequisitionRecordSub(objPoRequisitionDTO);
            return dt;

        }
 

        public DataTable getPartNo(string strHeadOfficeId,string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            PoRequisitionDAL objPoRequisitionDAL = new PoRequisitionDAL();


            dt = objPoRequisitionDAL.getPartNo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        
    }
}
