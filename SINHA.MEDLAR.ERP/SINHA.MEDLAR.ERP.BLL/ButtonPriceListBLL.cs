using SINHA.MEDLAR.ERP.DAL;
using SINHA.MEDLAR.ERP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.BLL
{
   public class ButtonPriceListBLL
    {
        public DataTable searchButtonPriceList(ButtonPriceListDTO objButtonPriceListDTO)
        {
            ButtonPriceListDAL objButtonPriceListDAL = new ButtonPriceListDAL();

            DataTable dt = new DataTable();

            dt = objButtonPriceListDAL.searchButtonPriceList(objButtonPriceListDTO);
            return dt;
        }
        public DataTable loadButtonPriceListRecord(ButtonPriceListDTO objButtonPriceListDTO)
        {
            ButtonPriceListDAL objButtonPriceListDAL = new ButtonPriceListDAL();

            DataTable dt = new DataTable();

            dt = objButtonPriceListDAL.loadButtonPriceListRecord(objButtonPriceListDTO);
            return dt;
        }
        public string deletePolybagSetupEntry(PolyBagDTO objPolyBagDTO)
        {
            string strMsg = "";
            PolyBagDAL objPolyBagDAL = new PolyBagDAL();


            strMsg = objPolyBagDAL.deletePolybagSetupEntry(objPolyBagDTO);
            return strMsg;
        }
        public string saveButtonPriceList(ButtonPriceListDTO objButtonPriceListDTO)
        {
            string strMsg = "";
            ButtonPriceListDAL objButtonPriceListDAL = new ButtonPriceListDAL();


            strMsg = objButtonPriceListDAL.saveButtonPriceList(objButtonPriceListDTO);
            return strMsg;


        }
        public string deleteButtonPriceListRecord(ButtonPriceListDTO objButtonPriceListDTO)
        {
            string strMsg = "";
            ButtonPriceListDAL objButtonPriceListDAL = new ButtonPriceListDAL();


            strMsg = objButtonPriceListDAL.deleteButtonPriceListRecord(objButtonPriceListDTO);
            return strMsg;
        }

        public DataTable GetSupplierId()
        {
            DataTable dt = new DataTable();

            ButtonPriceListDAL objButtonPriceListDAL = new ButtonPriceListDAL();

            dt = objButtonPriceListDAL.GetSupplierId();
            return dt;
        }

        public DataTable GetThreadSupplierId()
        {
            DataTable dt = new DataTable();

            ButtonPriceListDAL objButtonPriceListDAL = new ButtonPriceListDAL();

            dt = objButtonPriceListDAL.GetThreadSupplierId();
            return dt;
        }

        public DataTable GetColorId()
        {
            DataTable dt = new DataTable();


            
            ButtonPriceListDAL objButtonPriceListDAL = new ButtonPriceListDAL();

            dt = objButtonPriceListDAL.GetColorId();
            return dt;
        }
        public DataTable GetLineId()
        {
            DataTable dt = new DataTable();



            ButtonPriceListDAL objButtonPriceListDAL = new ButtonPriceListDAL();

            dt = objButtonPriceListDAL.GetLineId();
            return dt;
        }

        public DataTable GetArtId()
        {
            DataTable dt = new DataTable();



            ButtonPriceListDAL objButtonPriceListDAL = new ButtonPriceListDAL();

            dt = objButtonPriceListDAL.GetArtId();
            return dt;
        }

        public DataTable GetMesurementUnitId()
        {
            DataTable dt = new DataTable();
            CartoonPriceListDAL objCartoonPriceListDAL = new CartoonPriceListDAL();

            dt = objCartoonPriceListDAL.GetMesurementUnitId();
            return dt;
        }


        public DataTable getProgrammeId()
        {
            DataTable dt = new DataTable();

            ButtonPriceListDAL objButtonPriceListDAL = new ButtonPriceListDAL();

            dt = objButtonPriceListDAL.getProgrammeId();
            return dt;
        }

    }
}
