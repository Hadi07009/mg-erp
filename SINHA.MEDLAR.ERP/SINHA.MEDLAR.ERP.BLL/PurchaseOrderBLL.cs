using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class PurchaseOrderBLL
    {
        public string purchasOrderSave(PurchaseOrderDTO objPurchaseOrderDTO)
        {

            PurchaseOrderDAL objPurchaseOrderDAL = new PurchaseOrderDAL();


            string strMsg = objPurchaseOrderDAL.purchasOrderSave(objPurchaseOrderDTO);
            return strMsg;




        }


        public DataTable searchPurchaseOrderEntry(PurchaseOrderDTO objPurchaseOrderDTO)
        {

            PurchaseOrderDAL objPurchaseOrderDAL = new PurchaseOrderDAL();
            DataTable dt = new DataTable();

            dt = objPurchaseOrderDAL.searchPurchaseOrderEntry(objPurchaseOrderDTO);
            return dt;

        }




    }
}
