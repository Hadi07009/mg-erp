using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class MonthlyStoreBLL
    {
        public string saveMonthlyStoreInfo(MonthlyStoreDTO objMonthlyStoreDTO)
        {

            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();
            string strMsg = objMonthlyStoreDAL.saveMonthlyStoreInfo(objMonthlyStoreDTO);
            return strMsg;
        }

        public string MonthlyClosingBlance(MonthlyStoreDTO objMonthlyStoreDTO)
        {

            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();
            string strMsg = objMonthlyStoreDAL.MonthlyClosingBlance(objMonthlyStoreDTO);
            return strMsg;
        }


        public string deleteMonthlyRecord(MonthlyStoreDTO objMonthlyStoreDTO)
        {

            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();
            string strMsg = objMonthlyStoreDAL.deleteMonthlyRecord(objMonthlyStoreDTO);
            return strMsg;
        }


        public DataTable loadMonthlyStoreRecord(string strSparePartId, string strEquipementId, string strPartNo,string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();
            DataTable dt = new DataTable();

            dt = objMonthlyStoreDAL.loadMonthlyStoreRecord(strSparePartId, strEquipementId, strPartNo,  strYear,  strMonth, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public MonthlyStoreDTO searchEquipementAndSparePartId(string strTranId, string strHeadOfficeId, string strBranchOfficeId)
        {

            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();

            objMonthlyStoreDTO = objMonthlyStoreDAL.searchEquipementAndSparePartId(strTranId, strHeadOfficeId, strBranchOfficeId);
            return objMonthlyStoreDTO;

        }
        public MonthlyStoreDTO chkBeginingStock(string strTranId, string strPartNo, string strPartNoSearch, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();

            objMonthlyStoreDTO = objMonthlyStoreDAL.chkBeginingStock(strTranId, strPartNo, strPartNoSearch, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return objMonthlyStoreDTO;

        }
        public MonthlyStoreDTO searchMonthlyStoreRecord(string strTranId, string strPartNo, string strPartNoSearch, string strYear,string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();

            objMonthlyStoreDTO = objMonthlyStoreDAL.searchMonthlyStoreRecord(strTranId, strPartNo,strPartNoSearch, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return objMonthlyStoreDTO;

        }

        public MonthlyStoreDTO chkStockYn(string strTranId, string strPartNo, string strPartNoSearch, string strYear,string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();

            objMonthlyStoreDTO = objMonthlyStoreDAL.chkStockYn(strTranId, strPartNo, strPartNoSearch, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return objMonthlyStoreDTO;

        }


        public MonthlyStoreDTO searchBeginingStoreRecord(string strTranId, string strPartNo, string strPartNoSearch, string strYear,string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreDAL objMonthlyStoreDAL = new MonthlyStoreDAL();

            objMonthlyStoreDTO = objMonthlyStoreDAL.searchBeginingStoreRecord(strTranId, strPartNo,strPartNoSearch, strYear,strMonth, strHeadOfficeId, strBranchOfficeId);
            return objMonthlyStoreDTO;

        }


    }
}
