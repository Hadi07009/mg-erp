using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class ForeignFabricLcIssueBLL
    {

        public string saveForeignLcFabricIssue(ForeignFabricLcIssueDTO objForeignFabricLcIssueDTO)
        {
            string strMsg = "";

            ForeignFabricLcIssueDAL objForeignFabricLcIssueDAL = new ForeignFabricLcIssueDAL();


            strMsg = objForeignFabricLcIssueDAL.saveForeignLcFabricIssue(objForeignFabricLcIssueDTO);
            return strMsg;
        }


        public DataTable SearchForeignfabricIssue(ForeignFabricLcIssueDTO objForeignFabricLcIssueDTO)
        {

            ForeignFabricLcIssueDAL objForeignFabricLcIssueDAL = new ForeignFabricLcIssueDAL();
            DataTable dt = new DataTable();

            dt = objForeignFabricLcIssueDAL.SearchForeignfabricIssue(objForeignFabricLcIssueDTO);
            return dt;
        }


        public ForeignFabricLcIssueDTO searchForeignLcFabricTotalQty(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricLcIssueDTO objForeignFabricLcIssueDTO = new ForeignFabricLcIssueDTO();
            ForeignFabricLcIssueDAL objForeignFabricLcIssueDAL = new ForeignFabricLcIssueDAL();


            objForeignFabricLcIssueDTO = objForeignFabricLcIssueDAL.searchForeignLcFabricTotalQty(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOfficeId);

            return objForeignFabricLcIssueDTO;
        }


        public ForeignFabricLcIssueDTO searchForeignLcFabricIssueByInvoice(string strReceiveDate, string strInvoiceNo, string strTranId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricLcIssueDTO objForeignFabricLcIssueDTO = new ForeignFabricLcIssueDTO();
            ForeignFabricLcIssueDAL objForeignFabricLcIssueDAL = new ForeignFabricLcIssueDAL();


            objForeignFabricLcIssueDTO = objForeignFabricLcIssueDAL.searchForeignLcFabricIssueByInvoice(strReceiveDate, strInvoiceNo, strTranId, strHeadOfficeId, strBranchOfficeId);

            return objForeignFabricLcIssueDTO;
        }



        public string deleteForeignIssueRecord(ForeignFabricLcIssueDTO objForeignFabricLcIssueDTO)
        {
            string strMsg = "";

            ForeignFabricLcIssueDAL objForeignFabricLcIssueDAL = new ForeignFabricLcIssueDAL();


            strMsg = objForeignFabricLcIssueDAL.deleteForeignIssueRecord(objForeignFabricLcIssueDTO);
            return strMsg;
        }


    }
}
