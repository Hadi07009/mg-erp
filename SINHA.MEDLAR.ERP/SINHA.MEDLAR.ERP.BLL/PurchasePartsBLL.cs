using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class PurchasePartsBLL
    {

        public string savePurchasePartsRecord(PurchasePartsDTO objPurchasePartsDTO)
        {
            string strMsg = "";
            PurchasePartsDAL objPurchasePartsDAL = new PurchasePartsDAL();

            strMsg = objPurchasePartsDAL.savePurchasePartsRecord(objPurchasePartsDTO);

            return strMsg;
        }


        public string deletePurchasePartsRecord(PurchasePartsDTO objPurchasePartsDTO)
        {
            string strMsg = "";
            PurchasePartsDAL objPurchasePartsDAL = new PurchasePartsDAL();

            strMsg = objPurchasePartsDAL.deletePurchasePartsRecord(objPurchasePartsDTO);

            return strMsg;
        }

        public string deletePurchasePartsRecordById(PurchasePartsDTO objPurchasePartsDTO)
        {
            string strMsg = "";
            PurchasePartsDAL objPurchasePartsDAL = new PurchasePartsDAL();

            strMsg = objPurchasePartsDAL.deletePurchasePartsRecordById(objPurchasePartsDTO);

            return strMsg;
        }

        public DataTable loadPartsRecordSub(PurchasePartsDTO objPurchasePartsDTO)
        {

            DataTable dt = new DataTable();
            PurchasePartsDAL objPurchasePartsDAL = new PurchasePartsDAL();


            dt = objPurchasePartsDAL.loadPartsRecordSub(objPurchasePartsDTO);
            return dt;

        }

        public DataTable loadPartsRecordSubAll(PurchasePartsDTO objPurchasePartsDTO)
        {

            DataTable dt = new DataTable();
            PurchasePartsDAL objPurchasePartsDAL = new PurchasePartsDAL();


            dt = objPurchasePartsDAL.loadPartsRecordSubAll(objPurchasePartsDTO);
            return dt;

        }

        public PurchasePartsDTO searchPurchasePartsMain(string strRefNo, string strTranId, string strMachineId, string strSupplierId,  string strHeadOfficeId, string strBranchOfficeId)
        {

            PurchasePartsDTO objPoRequisitionDTO = new PurchasePartsDTO();
            PurchasePartsDAL objPurchasePartsDAL = new PurchasePartsDAL();

            objPoRequisitionDTO = objPurchasePartsDAL.searchPurchasePartsMain(strRefNo, strTranId, strMachineId, strSupplierId, strHeadOfficeId, strBranchOfficeId);

            return objPoRequisitionDTO;


        }

    }
}
