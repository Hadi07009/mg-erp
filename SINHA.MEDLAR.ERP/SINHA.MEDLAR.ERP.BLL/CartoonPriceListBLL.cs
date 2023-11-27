using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DAL;
using SINHA.MEDLAR.ERP.DTO;

using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class CartoonPriceListBLL
    {

        public string saveCartoonPriceList(CartoonPriceListDTO objCartoonPriceListDTO)
        {
            CartoonPriceListDAL objCartoonPriceListDAL = new CartoonPriceListDAL();
            string strMsg = "";
            strMsg = objCartoonPriceListDAL.saveCartoonPriceList(objCartoonPriceListDTO);
            return strMsg;
        }
        //Search Cartoon Price Record 
        public DataTable SearchCartoonPriceRecord(CartoonPriceListDTO objCartoonPriceListDTO)
        {
            CartoonPriceListDAL objCartoonPriceListDAL = new CartoonPriceListDAL();
            DataTable dt = new DataTable();
            dt = objCartoonPriceListDAL.SearchCartoonPriceRecord(objCartoonPriceListDTO);
            return dt;
        }
        //load Cartoon Price Record All
        public DataTable loadCartoonPriceList(string strHeadOfficeId, string strBranchOfficeId)
        {
            CartoonPriceListDAL objCartoonPriceListDAL = new CartoonPriceListDAL();
            DataTable dt = new DataTable();
            dt = objCartoonPriceListDAL.loadCartoonPriceList(strHeadOfficeId, strBranchOfficeId);
            return dt;
        }
        // gridView Delete button
        public string deleteCartoonPriceRecord(CartoonPriceListDTO objCartoonPriceListDTO)
        {
            string strMsg = "";
            CartoonPriceListDAL objCartoonPriceListDAL = new CartoonPriceListDAL();
            strMsg = objCartoonPriceListDAL.deleteCartoonPriceRecord(objCartoonPriceListDTO);
            return strMsg;
        }

        public DataTable GetMesurementUnitId()
        {
            DataTable dt = new DataTable();
            CartoonPriceListDAL objCartoonPriceListDAL = new CartoonPriceListDAL();

            dt = objCartoonPriceListDAL.GetMesurementUnitId();
            return dt;
        }
    }
}
