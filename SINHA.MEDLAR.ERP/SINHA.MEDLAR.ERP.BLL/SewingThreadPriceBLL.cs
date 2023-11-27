using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DAL;
using SINHA.MEDLAR.ERP.DTO;

using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class SewingThreadPriceBLL
    {


        public string saveSewingThreadPriceInfo(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {
            string strMsg = "";
            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();


            strMsg = objSewingThreadPriceDAL.saveSewingThreadPriceInfo(objSewingThreadPriceDTO);
            return strMsg;


        }

        public string deleteSewingThreadRecordById(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {
            string strMsg = "";
            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();


            strMsg = objSewingThreadPriceDAL.deleteSewingThreadRecordById(objSewingThreadPriceDTO);
            return strMsg;


        }

        public string deleteSewingThreadRecord(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {
            string strMsg = "";
            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();


            strMsg = objSewingThreadPriceDAL.deleteSewingThreadRecord(objSewingThreadPriceDTO);
            return strMsg;


        }


        public DataTable LoadSewingThreadRecord(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {

            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();
            DataTable dt = new DataTable();

            dt = objSewingThreadPriceDAL.LoadSewingThreadRecord(objSewingThreadPriceDTO);
            return dt;
        }


        public DataTable getCurrencyId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();


             dt = objSewingThreadPriceDAL.getCurrencyId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable getBrandId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();


            dt = objSewingThreadPriceDAL.getBrandId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public string saveSewingThreadOpeninigBalance(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {
            string strMsg = "";
            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();


            strMsg = objSewingThreadPriceDAL.saveSewingThreadOpeninigBalance(objSewingThreadPriceDTO);
            return strMsg;


        }



        public DataTable searchSewingThreadOpeningBalance(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {

            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();
            DataTable dt = new DataTable();

            dt = objSewingThreadPriceDAL.searchSewingThreadOpeningBalance(objSewingThreadPriceDTO);
            return dt;
        }


        public string deleteSewingThreadOpeningBalanceRecord(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {
            string strMsg = "";
            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();


            strMsg = objSewingThreadPriceDAL.deleteSewingThreadOpeningBalanceRecord(objSewingThreadPriceDTO);
            return strMsg;


        }

        public string deleteSewingThreadOpeninigBalanceRecordById(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {
            string strMsg = "";
            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();


            strMsg = objSewingThreadPriceDAL.deleteSewingThreadOpeninigBalanceRecordById(objSewingThreadPriceDTO);
            return strMsg;


        }



        public string saveSewingThreadReceiveInfo(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {
            string strMsg = "";
            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();


            strMsg = objSewingThreadPriceDAL.saveSewingThreadReceiveInfo(objSewingThreadPriceDTO);
            return strMsg;


        }

        public DataTable searchSewingThreadReceiveRecord(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {

            DataTable dt = new DataTable();
            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();


            dt = objSewingThreadPriceDAL.searchSewingThreadReceiveRecord(objSewingThreadPriceDTO);
            return dt;

        }

        public string deleteSewingThreadReceiveRecord(SewingThreadPriceDTO objSewingThreadPriceDTO)
        {

            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();
            string strMsg = objSewingThreadPriceDAL.deleteSewingThreadReceiveRecord(objSewingThreadPriceDTO);
            return strMsg;
        }



        public SewingThreadPriceDTO searchSewingThreadReceiveMain(string strReceiveDate, string SupplierId, string strHeadOfficeId, string strBranchOfficeId)
        {
            SewingThreadPriceDTO objSewingThreadPriceDTO = new SewingThreadPriceDTO();
            SewingThreadPriceDAL objSewingThreadPriceDAL = new SewingThreadPriceDAL();

            objSewingThreadPriceDTO = objSewingThreadPriceDAL.searchSewingThreadReceiveMain(strReceiveDate, SupplierId, strHeadOfficeId, strBranchOfficeId);

            return objSewingThreadPriceDTO;
        }












    }
}
