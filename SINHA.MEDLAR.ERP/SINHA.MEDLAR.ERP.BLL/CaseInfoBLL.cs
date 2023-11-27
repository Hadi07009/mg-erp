using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;


namespace SINHA.MEDLAR.ERP.BLL
{
    public class CaseInfoBLL
    {
        public string SaveCaseInfo(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";

            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            strMsg = objCaseInfoDAL.SaveCaseInfo(objCaseInfoDTO);
            return strMsg;
        }
        public string SaveTransferCaseInfo(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";

            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            strMsg = objCaseInfoDAL.SaveTransferCaseInfo(objCaseInfoDTO);
            return strMsg;
        }
        public DataTable GetCaseHistory(CaseInfoDTO objCaseInfoDTO)
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            dt = objCaseInfoDAL.GetCaseHistory(objCaseInfoDTO);
            return dt;
        }
        public string SaveCaseHistory(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";

            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            strMsg = objCaseInfoDAL.SaveCaseHistory(objCaseInfoDTO);
            return strMsg;
        }
        public string SaveWarrantInfo(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";

            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            strMsg = objCaseInfoDAL.SaveWarrantInfo(objCaseInfoDTO);
            return strMsg;
        }
        public string SaveHearingInfo(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";

            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            strMsg = objCaseInfoDAL.SaveHearingInfo(objCaseInfoDTO);
            return strMsg;
        }
        public string SaveDefendant(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";

            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            strMsg = objCaseInfoDAL.SaveDefendant(objCaseInfoDTO);
            return strMsg;
        }
        public string SaveComplaintant(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";

            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            strMsg = objCaseInfoDAL.SaveComplaintant(objCaseInfoDTO);
            return strMsg;
        }
        public string SaveCaseStatus(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";

            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            strMsg = objCaseInfoDAL.SaveCaseStatus(objCaseInfoDTO);
            return strMsg;
        }
        public string SaveCaseType(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";

            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            strMsg = objCaseInfoDAL.SaveCaseType(objCaseInfoDTO);
            return strMsg;
        }
        public string SaveCourtInfo(CaseInfoDTO objCaseInfoDTO)
        {
            string strMsg = "";

            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            strMsg = objCaseInfoDAL.SaveCourtInfo(objCaseInfoDTO);
            return strMsg;
        }
        public DataTable GetCaseStatus()
        {
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();

            DataTable dt = new DataTable();
            dt = objCaseInfoDAL.GetCaseStatus();
            return dt;
        }
        public DataTable GetCaseType()
        {
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();

            DataTable dt = new DataTable();
            dt = objCaseInfoDAL.GetCaseType();
            return dt;
        }
        public DataTable GetCourtInfo()
        {
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();

            DataTable dt = new DataTable();
            dt = objCaseInfoDAL.GetCourtInfo();
            return dt;
        }
        public DataTable LoadCaseInfoGrid(CaseInfoDTO objCaseInfoDTO)
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            dt = objCaseInfoDAL.LoadCaseInfoGrid(objCaseInfoDTO);
            return dt;
        }
        //GetTransferCaseInfo
        public DataTable GetTransferCaseInfo(CaseInfoDTO objCaseInfoDTO)
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            dt = objCaseInfoDAL.GetTransferCaseInfo(objCaseInfoDTO);
            return dt;
        }
        public DataTable GetSourseCaseInfo(CaseInfoDTO objCaseInfoDTO)
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            dt = objCaseInfoDAL.GetSourseCaseInfo(objCaseInfoDTO);
            return dt;
        }
        public DataTable GetHearingInfo(CaseInfoDTO objCaseInfoDTO)
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            dt = objCaseInfoDAL.GetHearingInfo(objCaseInfoDTO);
            return dt;
        }
        public DataTable GetWarrantInfo(CaseInfoDTO objCaseInfoDTO)
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            dt = objCaseInfoDAL.GetWarrantInfo(objCaseInfoDTO);
            return dt;
        }
        public DataTable GetComplaintant()
        {
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();

            DataTable dt = new DataTable();
            dt = objCaseInfoDAL.GetComplaintant();
            return dt;
        }
        public DataTable GetDefendant()
        {
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();

            DataTable dt = new DataTable();
            dt = objCaseInfoDAL.GetDefendant();
            return dt;
        }
        public CaseInfoDTO GetComplaintatnDefendantNameByCaseNo(CaseInfoDTO objCaseInfoDTO)
        {
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            objCaseInfoDTO = objCaseInfoDAL.GetComplaintatnDefendantNameByCaseNo(objCaseInfoDTO);
            return objCaseInfoDTO;
        }
        public CaseInfoDTO GetSourceCaseInformationBySourceCase(CaseInfoDTO objCaseInfoDTO)
        {
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            objCaseInfoDTO = objCaseInfoDAL.GetSourceCaseInformationBySourceCase(objCaseInfoDTO);
            return objCaseInfoDTO;
        }
        public List<CaseInfornation> GetCaseNoByCaseID(string caseNo)
        {

            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            DataTable dt = new DataTable();

            List<CaseInfornation> objCaseInfo = objCaseInfoDAL.GetCaseNoByCaseID(caseNo);



            return objCaseInfo;
        }
        //public DataTable GetDefendant()
        //{
        //    CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();

        //    DataTable dt = new DataTable();
        //    dt = objCaseInfoDAL.GetDefendant();
        //    return dt;
        //}

        public DataTable GetDefendantId()
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();


            dt = objCaseInfoDAL.GetDefendantId();
            return dt;
        }
        public DataTable GetComplaintantId()
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();


            dt = objCaseInfoDAL.GetComplaintantId();
            return dt;
        }
        public DataTable GetCaseStatusId()
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();


            dt = objCaseInfoDAL.GetCaseStatusId();
            return dt;
        }
       
        public DataTable GetActivityType()
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();


            dt = objCaseInfoDAL.GetActivityType();
            return dt;
        }
        public DataTable GetCaseId(string HeadOfficeId,string BranchOfficeId)
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();


            dt = objCaseInfoDAL.GetCaseId(HeadOfficeId, BranchOfficeId);
            return dt;
        }

        public DataTable GetSourceCase(string caseId)
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            dt = objCaseInfoDAL.GetSourceCase(caseId);
            return dt;
        }

        public DataTable GetInactiveSourceCase(string defendantId, string complainantId)
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            dt = objCaseInfoDAL.GetInactiveSourceCase(defendantId, complainantId);
            return dt;
        }

        public DataTable GetCaseTypeId()
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();


            dt = objCaseInfoDAL.GetCaseTypeId();
            return dt;
        }
        public DataTable GetCourtId()
        {
            DataTable dt = new DataTable();
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();


            dt = objCaseInfoDAL.GetCourtId();
            return dt;
        }
        public string DeleteSourceCaseInfo(CaseInfoDTO objCaseInfoDTO)
        {
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            string strMsg = objCaseInfoDAL.DeleteSourceCaseInfo(objCaseInfoDTO);
            return strMsg;
        }
        public string DeleteCaseHistory(CaseInfoDTO objCaseInfoDTO)
        {
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            string strMsg = objCaseInfoDAL.DeleteCaseHistory(objCaseInfoDTO);
            return strMsg;
        }
        #region Case Reminder
        //new
        public List<CaseInfoDTO> GetCaseReminder(string inquiryDate)
        {
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            DataTable dt = new DataTable();

            List<CaseInfoDTO> objCaseInfoList = objCaseInfoDAL.GetCaseReminder(inquiryDate);
            return objCaseInfoList;
        }
        //old
        public List<CaseInfoDTO> GetHearingReminder(string hearingDate)
        {
            CaseInfoDAL objCaseInfoDAL = new CaseInfoDAL();
            DataTable dt = new DataTable();

            List<CaseInfoDTO> objCaseInfoList = objCaseInfoDAL.GetHearingReminder(hearingDate);
            return objCaseInfoList;
        }

        #endregion
    }
}
