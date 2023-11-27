using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class ShipmentInfoBLL
    {

        public string saveShipmentInfo(ShipmentInfoDTO objShipmentInfoDTO)
        {

            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();
            string strMsg = objShipmentInfoDAL.saveShipmentInfo(objShipmentInfoDTO);
            return strMsg;
        }
        public DataTable LoadShipmentInfoSub(ShipmentInfoDTO objShipmentInfoDTO)
        {

            DataTable dt = new DataTable();
            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();


            dt = objShipmentInfoDAL.LoadShipmentInfoSub(objShipmentInfoDTO);
            return dt;

        }

        public ShipmentInfoDTO searchShipmentInfoMain(string strInvoiceNo, string strHeadOfficeId, string strBranchOfficeId)
        {


            ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();

            objShipmentInfoDTO = objShipmentInfoDAL.searchShipmentInfoMain(strInvoiceNo, strHeadOfficeId, strBranchOfficeId);

            return objShipmentInfoDTO;


        }
        public List<string> SearchInvoiceNo(string strInvoiceNo, string strBuyerId)
        {

            List<string> allInvoiceNo = new List<string>();

            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();


            allInvoiceNo = objShipmentInfoDAL.SearchInvoiceNo(strInvoiceNo, strBuyerId);
            return allInvoiceNo;

        }
        public string deleteShipmentInfoSubRecord(ShipmentInfoDTO objShipmentInfoDTO)
        {

            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();
            string strMsg = objShipmentInfoDAL.deleteShipmentInfoSubRecord(objShipmentInfoDTO);
            return strMsg;
        }
        public string deleteShipmentInfoRecord(ShipmentInfoDTO objShipmentInfoDTO)
        {

            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();
            string strMsg = objShipmentInfoDAL.deleteShipmentInfoRecord(objShipmentInfoDTO);
            return strMsg;
        }
        public ShipmentInfoDTO chkPONo(string strPONo, string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {


            ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();

            objShipmentInfoDTO = objShipmentInfoDAL.chkPONo(strPONo, strBuyerId, strHeadOfficeId, strBranchOfficeId);

            return objShipmentInfoDTO;
        }
        public ShipmentInfoDTO chkStyleNo(string strStyleNo, string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {


            ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
            ShipmentInfoDAL objShipmentInfoDAL = new ShipmentInfoDAL();

            objShipmentInfoDTO = objShipmentInfoDAL.chkStyleNo(strStyleNo, strBuyerId, strHeadOfficeId, strBranchOfficeId);

            return objShipmentInfoDTO;


        }
    }
}
