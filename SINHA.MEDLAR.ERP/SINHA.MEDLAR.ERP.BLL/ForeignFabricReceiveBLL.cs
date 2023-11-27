using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class ForeignFabricReceiveBLL
    {
        public DataTable getSupplierName()
        {
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();
            dt = objForeignFabricReceiveDAL.getSupplierName();
            return dt;
        }
        public DataTable getBuyerName()
        {
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();
            dt = objForeignFabricReceiveDAL.getBuyerName();
            return dt;
        }

        public DataTable getShipmentMode()
        {
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();
            dt = objForeignFabricReceiveDAL.getShipmentMode();
            return dt;
        }
        public DataTable getProgrammeName()
        {
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();
            dt = objForeignFabricReceiveDAL.getProgrammeName();
            return dt;
        }
        public DataTable getFabricName()
        {
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();
            dt = objForeignFabricReceiveDAL.getFabricName();
            return dt;
        }
        public DataTable getColorName()
        {
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();
            dt = objForeignFabricReceiveDAL.getColorName();
            return dt;
        }
        public DataTable getConstructionName()
        {
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();
            dt = objForeignFabricReceiveDAL.getConstructionName();
            return dt;
        }
        public DataTable getStyleName()
        {
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();
            dt = objForeignFabricReceiveDAL.getStyleName();
            return dt;
        }
        public DataTable getUnitName()
        {
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();
            dt = objForeignFabricReceiveDAL.getUnitName();
            return dt;
        }
        public DataTable getCurrencyName()
        {
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();
            dt = objForeignFabricReceiveDAL.getCurrencyName();
            return dt;
        }
        //Save Foreign Fabric Receive
        public string saveForeignLcFabricReceive(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {
            string strMsg = "";
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();


            strMsg = objForeignFabricReceiveDAL.saveForeignLcFabricReceive(objForeignFabricReceiveDTO);
            return strMsg;
        }

        public string deleteForeignLcFabricRecord(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {
            string strMsg = "";
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();


            strMsg = objForeignFabricReceiveDAL.deleteForeignLcFabricRecord(objForeignFabricReceiveDTO);
            return strMsg;
        }

        //Load data while saving
        public DataTable loadForeignfabricReceive(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {

            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();

            dt = objForeignFabricReceiveDAL.loadForeignfabricReceive(objForeignFabricReceiveDTO);
            return dt;
        }

        public DataTable SearchForeignfabricReceive(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {

            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();

            dt = objForeignFabricReceiveDAL.SearchForeignfabricReceive(objForeignFabricReceiveDTO);
            return dt;
        }


        public ForeignFabricReceiveDTO searchTotalForeignRcvQty( string strInvoiceNo,  string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();


            objForeignFabricReceiveDTO = objForeignFabricReceiveDAL.searchTotalForeignRcvQty( strInvoiceNo, strHeadOfficeId, strBranchOfficeId);

            return objForeignFabricReceiveDTO;
        }


        public ForeignFabricReceiveDTO searchForeignLcFabricByInvoice(string strReceiveDate, string strInvoiceNo,string strTranId, string strHeadOfficeId, string strBranchOfficeId)
        {
           
            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();


            objForeignFabricReceiveDTO = objForeignFabricReceiveDAL.searchForeignLcFabricByInvoice(strReceiveDate, strInvoiceNo, strTranId,  strHeadOfficeId, strBranchOfficeId);

            return objForeignFabricReceiveDTO;
        }

        public ForeignFabricReceiveDTO searchForeignLcFabricTotalQty(string strReceiveDate, string strInvoiceNo,string strBuyerId, string strSupplierId, string strFabricId, string strFabricConstructionId, string strColorId, string strStyleId, string strArtId, string strImporterId,string strProgrammeId,  string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();


            objForeignFabricReceiveDTO = objForeignFabricReceiveDAL.searchForeignLcFabricTotalQty(strReceiveDate, strInvoiceNo, strBuyerId, strSupplierId, strFabricId, strFabricConstructionId, strColorId, strStyleId, strArtId, strImporterId, strProgrammeId, strHeadOfficeId, strBranchOfficeId);

            return objForeignFabricReceiveDTO;
        }


        public ForeignFabricReceiveDTO searchForeignLcFabricReceiveTotalQty(string strReceiveDate, string strInvoiceNo, string strBuyerId, string strSupplierId, string strFabricId, string strFabricConstructionId, string strColorId, string strStyleId, string strArtId, string strImporterId, string strProgrammeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();


            objForeignFabricReceiveDTO = objForeignFabricReceiveDAL.searchForeignLcFabricReceiveTotalQty(strReceiveDate, strInvoiceNo, strBuyerId, strSupplierId, strFabricId, strFabricConstructionId, strColorId, strStyleId, strArtId, strImporterId, strProgrammeId, strHeadOfficeId, strBranchOfficeId);

            return objForeignFabricReceiveDTO;
        }

        public ForeignFabricReceiveDTO searchForeignFabricTotalQty(string strReceiveDate, string strInvoiceNo, string strBuyerId, string strSupplierId, string strFabricId, string strFabricConstructionId, string strColorId, string strStyleId, string strArtId, string strImporterId, string strProgrammeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();


            objForeignFabricReceiveDTO = objForeignFabricReceiveDAL.searchForeignFabricTotalQty(strReceiveDate, strInvoiceNo, strBuyerId, strSupplierId, strFabricId, strFabricConstructionId, strColorId, strStyleId, strArtId, strImporterId, strProgrammeId, strHeadOfficeId, strBranchOfficeId);

            return objForeignFabricReceiveDTO;
        }

        ////////////////////////////////////////////NEW/////////////////////////////////////////////////
        public string saveForeignFabricReceiveInfo(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {
            string strMsg = "";
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();


            strMsg = objForeignFabricReceiveDAL.saveForeignFabricReceiveInfo(objForeignFabricReceiveDTO);
            return strMsg;
        }

        public DataTable searcForeignFabricReceiveSub(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {


            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();

            dt = objForeignFabricReceiveDAL.searcForeignFabricReceiveSub(objForeignFabricReceiveDTO);

            return dt;


        }

        public ForeignFabricReceiveDTO searcForeignFabricReceiveMain(string strInvoice, string strReceiveDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            FOBDAL objFOBDAL = new FOBDAL();

            objForeignFabricReceiveDTO = objForeignFabricReceiveDAL.searcForeignFabricReceiveMain(strInvoice, strReceiveDate, strHeadOfficeId, strBranchOfficeId);

            return objForeignFabricReceiveDTO;


        }

        public string deleteForeignFabricReceiveRecord(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {

            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            string strMsg = objForeignFabricReceiveDAL.deleteForeignFabricReceiveRecord(objForeignFabricReceiveDTO);
            return strMsg;
        }
        public DataTable SearchForeignFabricReceive(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {


            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();

            dt = objForeignFabricReceiveDAL.SearchForeignFabricReceive(objForeignFabricReceiveDTO);

            return dt;


        }



        /////////////////////////////////////Fabric Assign/////////////////////////////////
        public string saveProgrammeFFSCAUCRecord(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {
            string strMsg = "";
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();


            strMsg = objForeignFabricReceiveDAL.saveProgrammeFFSCAUCRecord(objForeignFabricReceiveDTO);
            return strMsg;
        }

        public DataTable loadProgrammeFFSCAUC(ForeignFabricReceiveDTO objForeignFabricReceiveDTO)
        {


            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();
            DataTable dt = new DataTable();

            dt = objForeignFabricReceiveDAL.loadProgrammeFFSCAUC(objForeignFabricReceiveDTO);

            return dt;


        }

        public ForeignFabricReceiveDTO searchFabricAssign(string strTranId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveDAL objForeignFabricReceiveDAL = new ForeignFabricReceiveDAL();


            objForeignFabricReceiveDTO = objForeignFabricReceiveDAL.searchFabricAssign(strTranId, strHeadOfficeId, strBranchOfficeId);

            return objForeignFabricReceiveDTO;
        }



    }
}
