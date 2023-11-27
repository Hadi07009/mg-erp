using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class OfficeTimeDTO
    {

        private string strUnitId;
        private string strSectionId;
        private string strLogInTime;
        private string strLogOutTime;
        private string strLunchInTime;
        private string strLunchOutTime;
        
        private string strEffectDateFrom;
        private string strEffectDateTo;

        private string strUpdateBy;
        private string strUpdateDate;
        private string strHeadOfficeId;
        private string strHeadOfficeName;
        private string strBranchOfficeId;
        private string strBranchOfficeName;
        private string strAllUnit;


        private string strIftarActive;
        private string strIftarOutTime;
        private string strIftarInTime;
        private string strEffectDate;
        public string LogDate { get; set; }
        public string OTDeductionStartTime { get; set; }
        public string OTDeductionEndTime { get; set; }
        public string PurposeId { get; set; }
        public string SetupId { get; set; }
        public string DutyTypeId { get; set; }

        public string TimeId { get; set; }
        public string MappingId { get; set; }
        public string ShiftId { get; set; }
        public string CreateBy { get; set; }
        public string PunchStartTime { get; set; }
        public string PunchEndTime { get; set; }
        public string EffectDate
        {
            get { return strEffectDate; }
            set { strEffectDate = value; }
        }

        public string IftarActive
        {
            get { return strIftarActive; }
            set { strIftarActive = value; }
        }


        public string IftarOutTime
        {
            get { return strIftarOutTime; }
            set { strIftarOutTime = value; }
        }

        public string IftarInTime
        {
            get { return strIftarInTime; }
            set { strIftarInTime = value; }
        }

       
        public string AllUnit
        {
            get { return strAllUnit; }
            set { strAllUnit = value; }

        }

        public string UnitId
        {
            get { return strUnitId; }
            set { strUnitId = value; } 

        }

        public string SectionId
        {
            get { return strSectionId; }
            set { strSectionId = value; }

        }

        public string LogInTime
        {
            get { return strLogInTime; }
            set { strLogInTime = value; }

        }

        public string LogOutTime
        {
            get { return strLogOutTime; }
            set { strLogOutTime = value; }

        }

        public string LunchInTime
        {
            get { return strLunchInTime; }
            set { strLunchInTime = value; }

        }

        public string LunchOutTime
        {
            get { return strLunchOutTime; }
            set { strLunchOutTime = value; }

        }

        public string EffectDateFrom 
        {
            get { return strEffectDateFrom; }
            set { strEffectDateFrom = value; }

        }

        public string EffectDateTo
        {
            get { return strEffectDateTo; }
            set { strEffectDateTo = value; }

        }


        public string UpdateBy
        {
            get { return strUpdateBy; }
            set { strUpdateBy = value; }

        }

        public string UpdateDate
        {
            get { return strUpdateDate; }
            set { strUpdateDate = value; }

        }

        public string HeadOfficeId
        {
            get { return strHeadOfficeId; }
            set { strHeadOfficeId = value; }

        }

        public string HeadOfficeName
        {
            get { return strHeadOfficeName; }
            set { strHeadOfficeName = value; }

        }


        public string BranchOfficeId
        {
            get { return strBranchOfficeId; }
            set { strBranchOfficeId = value; }

        }
        public string BranchOfficeName
        {
            get { return strBranchOfficeName; }
            set { strBranchOfficeName = value; }

        }


    }
}
