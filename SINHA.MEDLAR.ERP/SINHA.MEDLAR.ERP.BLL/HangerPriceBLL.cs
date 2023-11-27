using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DAL;
using SINHA.MEDLAR.ERP.DTO;

using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class HangerPriceBLL
    {

        public string saveHangerPriceInfo(HangerPriceDTO objHangerPriceDTO)
        {
            string strMsg = "";
            HangerPriceDAL objHangerPriceDAL = new HangerPriceDAL();


            strMsg = objHangerPriceDAL.saveHangerPriceInfo(objHangerPriceDTO);
            return strMsg;


        }

        public DataTable LoadHangerPriceRecord(HangerPriceDTO objHangerPriceDTO)
        {

            HangerPriceDAL objHangerPriceDAL = new HangerPriceDAL();
            DataTable dt = new DataTable();

            dt = objHangerPriceDAL.LoadHangerPriceRecord(objHangerPriceDTO);
            return dt;
        }


        public string deleteHangerRecord(HangerPriceDTO objHangerPriceDTO)
        {
            string strMsg = "";
            HangerPriceDAL objHangerPriceDAL = new HangerPriceDAL();


            strMsg = objHangerPriceDAL.deleteHangerRecord(objHangerPriceDTO);
            return strMsg;


        }

        public string deleteHangerRecordById(HangerPriceDTO objHangerPriceDTO)
        {
            string strMsg = "";
            HangerPriceDAL objHangerPriceDAL = new HangerPriceDAL();


            strMsg = objHangerPriceDAL.deleteHangerRecordById(objHangerPriceDTO);
            return strMsg;


        }

        public DataTable getCurrencyId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            HangerPriceDAL objHangerPriceDAL = new HangerPriceDAL();


            dt = objHangerPriceDAL.getCurrencyId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable getColorId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            HangerPriceDAL objHangerPriceDAL = new HangerPriceDAL();


            dt = objHangerPriceDAL.getColorId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable getStyleId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            HangerPriceDAL objHangerPriceDAL = new HangerPriceDAL();


            dt = objHangerPriceDAL.getStyleId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


    }
}
