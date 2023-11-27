using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class PurchaseBLL
    {


        public string savePurchaseInfo(PurchaseDTO objPurchaseDTO)
        {

            string strMsg = "";

            PurchaseDAL objPurchaseDAL = new PurchaseDAL();

            strMsg = objPurchaseDAL.savePurchaseInfo(objPurchaseDTO);
            return strMsg;


        }

        public string PurchaseFileSave(PurchaseDTO objPurchaseDTO)
        {

            string strMsg = "";

            PurchaseDAL objPurchaseDAL = new PurchaseDAL();

            strMsg = objPurchaseDAL.PurchaseFileSave(objPurchaseDTO);
            return strMsg;


        }



        public PurchaseDTO searchInvoiceInfo(string strInvoiceNo, string strTranId)
        {

            DataTable dt = new DataTable();
            PurchaseDTO objPurchaseDTO = new PurchaseDTO();
            PurchaseDAL objPurchaseDAL = new PurchaseDAL();

            objPurchaseDTO = objPurchaseDAL.searchInvoiceInfo(strInvoiceNo, strTranId);

            return objPurchaseDTO;

        }

        public PurchaseDTO chkPDFFileExist(string strInvoiceNo, string strRequisitionNo)
        {

            DataTable dt = new DataTable();
            PurchaseDTO objPurchaseDTO = new PurchaseDTO();
            PurchaseDAL objPurchaseDAL = new PurchaseDAL();

            objPurchaseDTO = objPurchaseDAL.chkPDFFileExist(strInvoiceNo, strRequisitionNo);

            return objPurchaseDTO;

        }


    }
}
