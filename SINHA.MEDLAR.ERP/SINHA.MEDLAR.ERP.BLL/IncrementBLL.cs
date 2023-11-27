using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class IncrementBLL
    {

        public string processIncrement(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            string strMsg = objIncrementDAL.processIncrement(objIncrementDTO);
            return strMsg;
        }

        public string incrementSetupSave(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            string strMsg = objIncrementDAL.incrementSetupSave(objIncrementDTO);
            return strMsg;
        }

        public string addIncrementSetupSave(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            string strMsg = objIncrementDAL.addIncrementSetupSave(objIncrementDTO);
            return strMsg;
        }


        public string saveIncrementHO(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            string strMsg = objIncrementDAL.saveIncrementHO(objIncrementDTO);
            return strMsg;
        }

        public string saveIncrementProposalHO(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            string strMsg = objIncrementDAL.saveIncrementProposalHO(objIncrementDTO);
            return strMsg;
        }


        public string saveEmployeePerformance(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            string strMsg = objIncrementDAL.saveEmployeePerformance(objIncrementDTO);
            return strMsg;
        }

        public string processIncrementOption(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            string strMsg = objIncrementDAL.processIncrementOption(objIncrementDTO);
            return strMsg;
        }


        public DataTable searchBankSalaryEntry(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            DataTable dt = new DataTable();

            dt = objIncrementDAL.searchBankSalaryEntry(objIncrementDTO);
            return dt;

        }

        //new: 
        public DataTable GetIncrementProposalHO(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            DataTable dt = new DataTable();

            dt = objIncrementDAL.GetIncrementProposalHO(objIncrementDTO);
            return dt;

        }

        //old
        public DataTable searchIncrementRecord(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            DataTable dt = new DataTable();

            dt = objIncrementDAL.searchIncrementRecord(objIncrementDTO);
            return dt;

        }


        public DataTable searchEmployeeForPerformance(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            DataTable dt = new DataTable();

            dt = objIncrementDAL.searchEmployeeForPerformance(objIncrementDTO);
            return dt;

        }

        public DataTable searchIncrementRecordWorker(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            DataTable dt = new DataTable();

            dt = objIncrementDAL.searchIncrementRecordWorker(objIncrementDTO);
            return dt;

        }

        public DataTable searchEmployeeBankSalary(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            DataTable dt = new DataTable();

            dt = objIncrementDAL.searchEmployeeBankSalary(objIncrementDTO);
            return dt;

        }



        public DataTable searchIncrementEntryHO(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            DataTable dt = new DataTable();

            dt = objIncrementDAL.searchIncrementEntryHO(objIncrementDTO);
            return dt;

        }

        public DataTable searchIncrementProposalHO(IncrementDTO objIncrementDTO)
        {
            IncrementDAL objIncrementDAL = new IncrementDAL();
            DataTable dt = new DataTable();
            dt = objIncrementDAL.searchIncrementProposalHO(objIncrementDTO);
            return dt;
        }

        public DataTable searchIncrementProposalHO2(IncrementDTO objIncrementDTO)
        {
            IncrementDAL objIncrementDAL = new IncrementDAL();
            DataTable dt = new DataTable();
            dt = objIncrementDAL.searchIncrementProposalHO2(objIncrementDTO);
            return dt;
        }

        public DataTable searchEmployeePerformanceEntry(IncrementDTO objIncrementDTO)
        {

            IncrementDAL objIncrementDAL = new IncrementDAL();
            DataTable dt = new DataTable();

            dt = objIncrementDAL.searchEmployeePerformanceEntry(objIncrementDTO);
            return dt;

        }

        public string saveIncrememntAmount(IncrementDTO objIncrementDTO)
        {
            IncrementDAL objIncrementDAL = new IncrementDAL();
            string strMsg = "";

            strMsg = objIncrementDAL.saveIncrememntAmount(objIncrementDTO);
            return strMsg;

        }

        public IncrementDTO searchIncrementInfo(string strEmployeeId, string strHeadOfficeId)
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementDAL objIncrementDAL = new IncrementDAL();

            objIncrementDTO = objIncrementDAL.searchIncrementInfo(strEmployeeId, strHeadOfficeId);
            return objIncrementDTO;
        }

        public IncrementDTO searchIncrementAmountInfo(string strEmployeeId, string strIncrementYear,  string strHeadOfficeId, string strBranchOfficeId)
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementDAL objIncrementDAL = new IncrementDAL();

            objIncrementDTO = objIncrementDAL.searchIncrementAmountInfo(strEmployeeId, strIncrementYear, strHeadOfficeId, strBranchOfficeId);
            return objIncrementDTO;
        }

        public IncrementDTO searchGrossSalaryForIncrement(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOfficeId)
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementDAL objIncrementDAL = new IncrementDAL();

            objIncrementDTO = objIncrementDAL.searchGrossSalaryForIncrement(strEmployeeId, strIncrementYear, strHeadOfficeId, strBranchOfficeId);
            return objIncrementDTO;
        }
        public IncrementDTO searchMaxGrossSalary(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOfficeId)
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementDAL objIncrementDAL = new IncrementDAL();

            objIncrementDTO = objIncrementDAL.searchMaxGrossSalary(strEmployeeId, strIncrementYear, strHeadOfficeId, strBranchOfficeId);
            return objIncrementDTO;
        }

        public IncrementDTO searchIncrementProposalInfoHO(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOfficeId)
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementDAL objIncrementDAL = new IncrementDAL();

            objIncrementDTO = objIncrementDAL.searchIncrementProposalInfoHO(strEmployeeId, strIncrementYear, strHeadOfficeId, strBranchOfficeId);
            return objIncrementDTO;
        }

        public IncrementDTO searchPerformanceRecord(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOfficeId)
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementDAL objIncrementDAL = new IncrementDAL();

            objIncrementDTO = objIncrementDAL.searchPerformanceRecord(strEmployeeId, strIncrementYear, strHeadOfficeId, strBranchOfficeId);
            return objIncrementDTO;
        }


    }
}
