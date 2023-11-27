using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
using System.Collections.Specialized;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class FabricIssueBLL
    {


        public string saveFabricIssueSub(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.saveFabricIssueSub(objFabricIssueDTO);
            return strMsg;

        }

        public string saveLocalFabricReceivePI(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.saveLocalFabricReceivePI(objFabricIssueDTO);
            return strMsg;

        }

        public string saveZipperIssue(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.saveZipperIssue(objFabricIssueDTO);
            return strMsg;

        }


        public string saveZipperReceive(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.saveZipperReceive(objFabricIssueDTO);
            return strMsg;

        }

        public string deleteLocalFabricReceivePI(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.deleteLocalFabricReceivePI(objFabricIssueDTO);
            return strMsg;

        }

        public string deleteZipperIssue(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.deleteZipperIssue(objFabricIssueDTO);
            return strMsg;

        }


        public string deleteZipperReceive(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.deleteZipperReceive(objFabricIssueDTO);
            return strMsg;

        }

        public string saveLocalFabricReceive(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.saveLocalFabricReceive(objFabricIssueDTO);
            return strMsg;

        }

        public string deleteLocalFabricReceive(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.deleteLocalFabricReceive(objFabricIssueDTO);
            return strMsg;

        }

        public string deleteForeignFabricIssue(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.deleteForeignFabricIssue(objFabricIssueDTO);
            return strMsg;

        }

        public string processForeignFabricIssueFromReceive(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.processForeignFabricIssueFromReceive(objFabricIssueDTO);
            return strMsg;

        }

        public string saveLocalFabricAcceptance(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.saveLocalFabricAcceptance(objFabricIssueDTO);
            return strMsg;

        }


        public string saveLocalFabricIssue(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.saveLocalFabricIssue(objFabricIssueDTO);
            return strMsg;

        }


        public string deleteLocalFabricAcceptance(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.deleteLocalFabricAcceptance(objFabricIssueDTO);
            return strMsg;

        }

        public string deleteLocalFabricIssue(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            string strMsg = objFabricIssueDAL.deleteLocalFabricIssue(objFabricIssueDTO);
            return strMsg;

        }

        public DataTable searchForeignFabricIssueSub(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchForeignFabricIssueSub(objFabricIssueDTO);
            return dt;

        }


        public DataTable searchFabricReceivePI(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchFabricReceivePI(objFabricIssueDTO);
            return dt;

        }

        public DataTable searchZipperIssueRecord(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchZipperIssueRecord(objFabricIssueDTO);
            return dt;

        }

        public DataTable searchZipperIssueRecordEntry(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchZipperIssueRecordEntry(objFabricIssueDTO);
            return dt;

        }


        public DataTable searchFabricReceiveEntryPI(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchFabricReceiveEntryPI(objFabricIssueDTO);
            return dt;

        }

        public DataTable searchZipperReceiveEntry(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchZipperReceiveEntry(objFabricIssueDTO);
            return dt;

        }

        public DataTable searchZipperReceiveEntryRecord(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchZipperReceiveEntryRecord(objFabricIssueDTO);
            return dt;

        }


        public DataTable searchFabricReceive(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchFabricReceive(objFabricIssueDTO);
            return dt;

        }

        public DataTable searchFabricReceiveFromPI(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchFabricReceiveFromPI(objFabricIssueDTO);
            return dt;

        }
        public DataTable searchFabricRecePI(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchFabricRecePI(objFabricIssueDTO);
            return dt;

        }

        public DataTable searchFabricReceiveFromSupplier(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchFabricReceiveFromSupplier(objFabricIssueDTO);
            return dt;

        }

        public DataTable searchZipperReceiveSub(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchZipperReceiveSub(objFabricIssueDTO);
            return dt;

        }

        public DataTable searchFabricReceiveEntry(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchFabricReceiveEntry(objFabricIssueDTO);
            return dt;

        }


        public DataTable searchFabricAcceptanceMain(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchFabricAcceptanceMain(objFabricIssueDTO);
            return dt;

        }

        public DataTable searchFabricAcceptanceFromReceive(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchFabricAcceptanceFromReceive(objFabricIssueDTO);
            return dt;

        }

        public DataTable searchFabricIssue(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchFabricIssue(objFabricIssueDTO);
            return dt;

        }

        public DataTable searchFabricIssueEntry(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchFabricIssueEntry(objFabricIssueDTO);
            return dt;

        }
        public FabricIssueDTO searchLocalFabricAcceptanceSub(string strChalanNo,string strAcceptanceDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            objFabricIssueDTO = objFabricIssueDAL.searchLocalFabricAcceptanceSub(strChalanNo, strAcceptanceDate, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;

        }

        public FabricIssueDTO searchDNNo(string strPoNo, string strChallanNo, string strPINo, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            objFabricIssueDTO = objFabricIssueDAL.searchDNNo(strPoNo, strChallanNo, strPINo, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;

        }





        public FabricIssueDTO searchForeignFabricMain( string strChalanNo,string strIssueDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            objFabricIssueDTO = objFabricIssueDAL.searchForeignFabricMain(strChalanNo, strIssueDate, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;

        }


        public FabricIssueDTO searchFabricInfoPI(string PONo, string strPINo, string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            objFabricIssueDTO = objFabricIssueDAL.searchFabricInfoPI(PONo, strPINo, strReceiveDate, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;

        }

        public FabricIssueDTO searchZipperInfo(string strChallanNo,string strIssueDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            objFabricIssueDTO = objFabricIssueDAL.searchZipperInfo(strChallanNo, strIssueDate, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;

        }


        public FabricIssueDTO searchZipperReceiveRecord(string strInvoiceNo, string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            objFabricIssueDTO = objFabricIssueDAL.searchZipperReceiveRecord(strInvoiceNo, strReceiveDate, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;

        }

        public FabricIssueDTO searchFabricReceEntry(string strChallanNo, string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            objFabricIssueDTO = objFabricIssueDAL.searchFabricReceEntry(strChallanNo, strReceiveDate,strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;

        }

        public FabricIssueDTO searchFabrciReceiveSupp(string strChallanNo, string strPONo, string strPINo,  string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            objFabricIssueDTO = objFabricIssueDAL.searchFabrciReceiveSupp(strChallanNo, strPONo, strPINo, strReceiveDate, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;

        }

        public FabricIssueDTO searchFabricAcceptanceYn(string strPONo, string strChallanNo, string strPINo, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            objFabricIssueDTO = objFabricIssueDAL.searchFabricAcceptanceYn(strPONo,strChallanNo, strPINo, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;

        }

        public FabricIssueDTO searchFabrciReceiveEntryPI(string strChallanNo, string strPONo, string strPINo, string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();

            objFabricIssueDTO = objFabricIssueDAL.searchFabrciReceiveEntryPI(strChallanNo, strPONo, strPINo, strReceiveDate, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;

        }


        public FabricIssueDTO searcLocalFabricReceiveMain(string strChallanNo, string strReceiveDte, string strSupplierId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();

            objFabricIssueDTO = objFabricIssueDAL.searcLocalFabricReceiveMain(strChallanNo, strReceiveDte, strSupplierId, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;


        }

        public FabricIssueDTO searcLocalFabricIssueMain(string strChallanNo, string strReceiveDte, string strSupplierId, string strStoreId, string strHeadOfficeId, string strBranchOfficeId)
        {


            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();

            objFabricIssueDTO = objFabricIssueDAL.searcLocalFabricIssueMain(strChallanNo, strReceiveDte, strSupplierId, strStoreId, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;


        }



        public DataTable searchFabricReceiveSub(FabricIssueDTO objFabricIssueDTO)
        {

            DataTable dt = new DataTable();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            dt = objFabricIssueDAL.searchFabricReceiveSub(objFabricIssueDTO);
            return dt;

        }

        public FabricIssueDTO searchForeignLcFabricTotalQty(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            objFabricIssueDTO = objFabricIssueDAL.searchForeignLcFabricTotalQty(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;
        }

        public FabricIssueDTO searchForeignFabricTotalRcvQty(string strSupplierId, string strProgrammeId, string strFabricId, string strConstructionId, string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            objFabricIssueDTO = objFabricIssueDAL.searchForeignFabricTotalRcvQty(strSupplierId, strProgrammeId, strFabricId, strConstructionId, strStyleId, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;
        }

        public FabricIssueDTO searchSingleQty(string strSupplierId, string strProgrammeId, string strFabricId, string strConstructionId, string strStyleId, string strArtId, string strColorId, string strUnitId, string strHeadOfficeId, string strBranchOfficeId)
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();


            objFabricIssueDTO = objFabricIssueDAL.searchSingleQty(strSupplierId, strProgrammeId, strFabricId, strConstructionId, strStyleId, strArtId, strColorId, strUnitId, strHeadOfficeId, strBranchOfficeId);

            return objFabricIssueDTO;
        }

        public DataTable SearchForeignfabricIssue(FabricIssueDTO objFabricIssueDTO)
        {

            FabricIssueDAL objFabricIssueDAL = new FabricIssueDAL();
            DataTable dt = new DataTable();

            dt = objFabricIssueDAL.SearchForeignfabricIssue(objFabricIssueDTO);

            return dt;
        }


    }
}
