using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
   public class POAssignBLL
    {

        public DataTable ShowPOAssignRecord(POAssignDTO objPOAssignDTO)
        {

            //POAssignDTO objPOAssignDTO = new POAssignDTO();
            POAssignDAL objPOAssignDAL = new POAssignDAL();

            DataTable dt = new DataTable();

            dt = objPOAssignDAL.ShowPOAssignRecord(objPOAssignDTO);
            return dt;

        }
        public DataTable loadPOAssignRecord(POAssignDTO objPOAssignDTO)
        {

            //POAssignDTO objPOAssignDTO = new POAssignDTO();
            POAssignDAL objPOAssignDAL = new POAssignDAL();

            DataTable dt = new DataTable();

            dt = objPOAssignDAL.loadPOAssignRecord(objPOAssignDTO);
            return dt;

        }

        public POAssignDTO searchPOAssignnfo(string strPOIdId)
        {

            POAssignDTO objPOAssignDTO = new POAssignDTO();
            POAssignDAL objPOAssignDAL = new POAssignDAL();

            objPOAssignDTO = objPOAssignDAL.searchPOAssignnfo(strPOIdId);
            return objPOAssignDTO;

        }
        public POAssignDTO searchLineName(string strPoId,string strHeadOfficeId,string strBranchOfficeId)
        {

            POAssignDTO objPOAssignDTO = new POAssignDTO();
            POAssignDAL objPOAssignDAL = new POAssignDAL();

            objPOAssignDTO = objPOAssignDAL.searchLineName(strPoId, strHeadOfficeId, strBranchOfficeId);
            return objPOAssignDTO;

        }


        public string SavePOAssignInfo(POAssignDTO objPOAssignDTO)
        {
            string strMsg = "";
            POAssignDAL objPOAssignDAL = new POAssignDAL();


            strMsg = objPOAssignDAL.SavePOAssignInfo(objPOAssignDTO);
            return strMsg;


        }

        public string deletePOAssignRecord(POAssignDTO objPOAssignDTO)
        {
            string strMsg = "";
            POAssignDAL objPOAssignDAL = new POAssignDAL();


            strMsg = objPOAssignDAL.deletePOAssignRecord(objPOAssignDTO);
            return strMsg;


        }



    }
}
