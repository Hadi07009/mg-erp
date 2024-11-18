using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class TiffinBLL
    {
        public string procesTiffin(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.procesTiffin(objTiffinDTO);
            return strMsg;

        }
        public string saveTiffinInfo(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.saveTiffinInfo(objTiffinDTO);
            return strMsg;

        }


        public string monthlyDayForTiffin(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.monthlyDayForTiffin(objTiffinDTO);
            return strMsg;

        }

        public string monthlyDayForNightBill(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.monthlyDayForNightBill(objTiffinDTO);
            return strMsg;

        }

        public string monthlyDayForTiffinStaff(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.monthlyDayForTiffinStaff(objTiffinDTO);
            return strMsg;

        }

        public string monthlyDayForNightBillStaff(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.monthlyDayForNightBillStaff(objTiffinDTO);
            return strMsg;

        }


        public string saveWorkerIncrementProposal(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.saveWorkerIncrementProposal(objTiffinDTO);
            return strMsg;

        }

        public string processIncrementProposal(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.processIncrementProposal(objTiffinDTO);
            return strMsg;

        }

        public string processIncrementProposalAll(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.processIncrementProposalAll(objTiffinDTO);
            return strMsg;

        }

        public string processIncrementProposalStaff(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.processIncrementProposalStaff(objTiffinDTO);
            return strMsg;

        }

        public string processIncrementProposalSummery(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.processIncrementProposalSummery(objTiffinDTO);
            return strMsg;

        }

        public string processMonthlyIncrementProposalWorkerSummery(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.processMonthlyIncrementProposalWorkerSummery(objTiffinDTO);
            return strMsg;

        }


        public string processIncrementProposalSummeryStaff(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.processIncrementProposalSummeryStaff(objTiffinDTO);
            return strMsg;

        }

        public string processTiffinOption(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.processTiffinOption(objTiffinDTO);
            return strMsg;
        }


        public DataTable searchEmployeeRecordforTiffin(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            dt = objTiffinDAL.searchEmployeeRecordforTiffin(objTiffinDTO);
            return dt;

        }

        public DataTable searchEmployeeRecordforIncrementProposal(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            dt = objTiffinDAL.searchEmployeeRecordforIncrementProposal(objTiffinDTO);
            return dt;

        }

        
        public DataTable searchEmployeeRecordforIncrementProposalStaff(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            dt = objTiffinDAL.searchEmployeeRecordforIncrementProposalStaff(objTiffinDTO);
            return dt;

        }

        public DataTable searchTiffinEntry(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            dt = objTiffinDAL.searchTiffinEntry(objTiffinDTO);
            return dt;

        }

        public DataTable searchNightBillEntry(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            dt = objTiffinDAL.searchNightBillEntry(objTiffinDTO);
            return dt;

        }

        public DataTable searchIncrementProposalEntry(TiffinDTO objTiffinDTO)
        {
            DataTable dt = new DataTable();
            TiffinDAL objTiffinDAL = new TiffinDAL();
            
            dt = objTiffinDAL.searchIncrementProposalEntry(objTiffinDTO);
            return dt;
        }

        public DataTable searchIncrementProposalEntryAll(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            dt = objTiffinDAL.searchIncrementProposalEntryAll(objTiffinDTO);
            return dt;

        }

        public DataTable searchIncrementProposalEntryStaff(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            dt = objTiffinDAL.searchIncrementProposalEntryStaff(objTiffinDTO);
            return dt;

        }

        public DataTable searchWorkerPromotionEntry(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            dt = objTiffinDAL.searchWorkerPromotionEntry(objTiffinDTO);
            return dt;

        }

        public DataTable searchWorkerPromotion(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            dt = objTiffinDAL.searchWorkerPromotion(objTiffinDTO);
            return dt;

        }

        public DataTable searchEmployeePromotion(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            dt = objTiffinDAL.searchEmployeePromotion(objTiffinDTO);
            return dt;

        }


        public DataTable searchEmployeePromotionEntry(TiffinDTO objTiffinDTO)
        {

            DataTable dt = new DataTable();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            dt = objTiffinDAL.searchEmployeePromotionEntry(objTiffinDTO);
            return dt;

        }



        public TiffinDTO getTiffinDay(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            objTiffinDTO = objTiffinDAL.getTiffinDay(strEmployeeId, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return objTiffinDTO;

        }

        public TiffinDTO getTiffinAmount(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            objTiffinDTO = objTiffinDAL.getTiffinAmount(strEmployeeId, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return objTiffinDTO;

        }

        public TiffinDTO getIftarDayOnly(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            objTiffinDTO = objTiffinDAL.getIftarDayOnly(strEmployeeId, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return objTiffinDTO;

        }


        public TiffinDTO getTiffinDayOnly(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinDAL objTiffinDAL = new TiffinDAL();


            objTiffinDTO = objTiffinDAL.getTiffinDayOnly(strEmployeeId, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return objTiffinDTO;

        }

        public string ProcessIncrementProposalReqSummary(TiffinDTO objTiffinDTO)
        {

            TiffinDAL objTiffinDAL = new TiffinDAL();
            string strMsg = objTiffinDAL.ProcessIncrementProposalReqSummary(objTiffinDTO);
            return strMsg;

        }
    }
}
