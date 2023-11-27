using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class BuyerBLL
    {

        public string saveBuyerInformation(BuyerDTO objBuyerDTO)
        {

            BuyerDAL objBuyerDAL = new BuyerDAL();
            string strMsg = "";

            strMsg = objBuyerDAL.saveBuyerInformation(objBuyerDTO);
            return strMsg;
        }

        public BuyerDTO searchBuyerRecord(string strBuyerId)
        {
            BuyerDTO objBuyerDTO = new BuyerDTO();
            BuyerDAL objBuyerDAL = new BuyerDAL();

            objBuyerDTO = objBuyerDAL.searchBuyerRecord(strBuyerId);
            return objBuyerDTO;

        }

        public string saveBuyerEntryRecord(BuyerDTO objBuyerDTO)
        {
            string strMsg = "";
            BuyerDAL objBuyerDAL = new BuyerDAL();



            strMsg = objBuyerDAL.saveBuyerEntryRecord(objBuyerDTO);
            return strMsg;


        }
        public string saveSupplierInfo(BuyerDTO objBuyerDTO)
        {

            BuyerDAL objBuyerDAL = new BuyerDAL();
            string strMsg = "";

            strMsg = objBuyerDAL.saveSupplierInfo(objBuyerDTO);
            return strMsg;
        }


        public DataTable loadBuyerEntry(string strHeadOfficeId, string strBranchOfficeId)
        {

            BuyerDTO objBuyerDTO = new BuyerDTO();
            BuyerDAL objBuyerDAL = new BuyerDAL();
            DataTable dt = new DataTable();

            dt = objBuyerDAL.loadBuyerEntry(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
    }
}
