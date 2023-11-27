using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class ProductReceivedBLL
    {



        public string saveProductReceivedInfo(ProductReceivedDTO objProductReceivedDTO)
        {

            ProductReceivedDAL objProductReceivedDAL = new ProductReceivedDAL();
            string strMsg = objProductReceivedDAL.saveProductReceivedInfo(objProductReceivedDTO);
            return strMsg;
        }

        public DataTable loadProductReceivedInfo(ProductReceivedDTO objProductReceivedDTO)
        {

            DataTable dt = new DataTable();
            ProductReceivedDAL objPoRequisitionDAL = new ProductReceivedDAL();


            dt = objPoRequisitionDAL.loadProductReceivedInfo(objProductReceivedDTO);
            return dt;

        }
        public DataTable searchProductReceivedInfo(ProductReceivedDTO objProductReceivedDTO)
        {

            DataTable dt = new DataTable();
            ProductReceivedDAL objProductReceivedDAL = new ProductReceivedDAL();


            dt = objProductReceivedDAL.searchProductReceivedInfo(objProductReceivedDTO);
            return dt;

        }

        public ProductReceivedDTO CheckSavedData(string strPartNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            ProductReceivedDTO objProductReceivedDTO = new ProductReceivedDTO();
            ProductReceivedDAL objProductReceivedDAL = new ProductReceivedDAL();

            objProductReceivedDTO = objProductReceivedDAL.CheckSavedData(strPartNo,strHeadOfficeId, strBranchOfficeId);
            return objProductReceivedDTO;
        }

        public string deleteProductReceivedRecord(ProductReceivedDTO objProductReceivedDTO)
        {

            ProductReceivedDAL objProductReceivedDAL = new ProductReceivedDAL();
            string strMsg = objProductReceivedDAL.deleteProductReceivedRecord(objProductReceivedDTO);
            return strMsg;
        }

    }
}
