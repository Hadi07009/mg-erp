using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class PoTrackingBLL
    {
        public string savePoTrackingInfo(PoTrackingDTO objPoTrackingDTO)
        {

            PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();
            string strMsg = objPoTrackingDAL.savePoTrackingInfo(objPoTrackingDTO);
            return strMsg;
        }
        public string savePoTrackingAdvanceInfo(PoTrackingDTO objPoTrackingDTO)
        {

            PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();
            string strMsg = objPoTrackingDAL.savePoTrackingAdvanceInfo(objPoTrackingDTO);
            return strMsg;
        }
        public PoTrackingDTO searchPoTotalAmount(string strPoNumber, string strHeadOfficeId, string strBranchOfficeId)
        {
            PoTrackingDTO objPoTrackingDTO = new PoTrackingDTO();
            PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();
            objPoTrackingDTO = objPoTrackingDAL.searchPoTotalAmount( strPoNumber,  strHeadOfficeId,  strBranchOfficeId);
            return objPoTrackingDTO;
        }
        public DataTable LoadPoTrackingAdvanceInfo(string strPoNumber, string strHeadOfficeId, string strBranchOfficeId)
        {
            DataTable dt = new DataTable();
            PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();
            dt = objPoTrackingDAL.LoadPoTrackingAdvanceInfo(strPoNumber, strHeadOfficeId, strBranchOfficeId);
            return dt;
        }
        public DataTable SearchPoNo(string strPoNumber,string strHeadOfficeId,string strBranchOfficeId)
        {

            DataTable dt = new DataTable();

            PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();


            dt = objPoTrackingDAL.SearchPoNo( strPoNumber, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        //public  List<string> SearchPoNo(string strPoNumber )
        //{

        //   // DataTable dt = new DataTable();
        //    List<string> allPoNumber = new List<string>();

        //    PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();


        //    allPoNumber = objPoTrackingDAL.SearchPoNo(strPoNumber);
        //    return allPoNumber;

        //}
        public DataTable LoadPoTrackingRecord(string strPoNumber,string strHeadOfficeId,string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();


            dt = objPoTrackingDAL.LoadPoTrackingRecord(strPoNumber, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable searchPoTrackingMainOne(string strPoNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();


            dt = objPoTrackingDAL.searchPoTrackingMainOne(strPoNo, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable searchPoTrackingMainTwo(string strPoNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();


            dt = objPoTrackingDAL.searchPoTrackingMainTwo(strPoNo, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public string deletePoTrackingSubAdvancedRecord(PoTrackingDTO objPoTrackingDTO)
        {

            PoTrackingDAL objPoTrackingDAL = new PoTrackingDAL();
            string strMsg = objPoTrackingDAL.deletePoTrackingSubAdvancedRecord(objPoTrackingDTO);
            return strMsg;
        }
    }
}
