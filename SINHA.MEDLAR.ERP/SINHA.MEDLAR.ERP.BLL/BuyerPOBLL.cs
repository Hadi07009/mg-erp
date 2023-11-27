using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class BuyerPOBLL
    {

        public string buyerPOsave(BuyerPODTO objBuyerPODTO)
        {

            BuyerPODAL objBuyerPODALL = new BuyerPODAL();
            string strMsg = "";

            strMsg = objBuyerPODALL.buyerPOsave(objBuyerPODTO);
            return strMsg;
        }

        public string saveBuyerMeasurement(BuyerPODTO objBuyerPODTO)
        {

            BuyerPODAL objBuyerPODALL = new BuyerPODAL();
            string strMsg = "";

            strMsg = objBuyerPODALL.saveBuyerMeasurement(objBuyerPODTO);
            return strMsg;
        }


        public DataTable searchBuyerPO(BuyerPODTO objBuyerPODTO)
        {

            DataTable dt = new DataTable();
            BuyerPODAL objBuyerPODALL = new BuyerPODAL();


            dt = objBuyerPODALL.searchBuyerPO(objBuyerPODTO);
            return dt;

        }

        public DataTable searchBuyerMeasurement(BuyerPODTO objBuyerPODTO)
        {

            DataTable dt = new DataTable();
            BuyerPODAL objBuyerPODALL = new BuyerPODAL();


            dt = objBuyerPODALL.searchBuyerMeasurement(objBuyerPODTO);
            return dt;

        }


        public BuyerPODTO searchPoEntry(string strPONo, string strHeadOfficeId, string strBranchOffiecId)
        {

            BuyerPODTO objBuyerPODTO = new BuyerPODTO();
            BuyerPODAL objBuyerPODALL = new BuyerPODAL();
          

            objBuyerPODTO = objBuyerPODALL.searchPoEntry(strPONo, strHeadOfficeId, strBranchOffiecId);
            return objBuyerPODTO;
        }


    }
}
