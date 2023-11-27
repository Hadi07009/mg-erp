using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
   public class GazetteDTO
    {
        private string strFromDate;
        private string strToDate;
        private string strEmployeeId;
        private string strDepartmentId;
        private string strUnitId;
        private string strSectionId;
        private string strCatagoryId;
        private string strDesignationId;
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBY;
        private string strYear;
        private string strMonth;
        private string strCardNo;
        private string strFromMonthId;
        private string strToMonthId;
        private string strPunchCode;
        
        
        private string strFromMonth;
        private string strToMonth;
        public string UnitGroupId { get; set; }
        public string IncrementYn { get; set; }
        public string FinalizedYn { get; set; }
        public string AnalysisYn { get; set; }
        public string FinalizedLock { get; set; }
        public string AnalysisLock { get; set; }
        public string ActiveYn { get; set; }
        public string GazetteYear { get; set; }
        public string Id { get; set; }


        public string IncrementYear { get; set; }
        public string IncrementMonth { get; set; }

        public string ArrearYear { get; set; }
        public string ArrearMonth { get; set; }


        public string ToMonth
        {
            get { return strToMonth; }
            set { strToMonth = value; }
        }

        public string FromMonth
        {
            get { return strFromMonth; }
            set { strFromMonth = value; }

        }
        
        public string PunchCode
        {
            get { return strPunchCode; }
            set { strPunchCode = value; }
        }
                
        public string FromDate
        {
            get { return strFromDate; }
            set { strFromDate = value; }

        }
        public string FromMonthId
        {
            get { return strFromMonthId; }
            set { strFromMonthId = value; }

        }
        public string ToMonthId
        {
            get { return strToMonthId; }
            set { strToMonthId = value; }

        }
        
        public string CardNo
        {
            get { return strCardNo; }
            set { strCardNo = value; }

        }
        
        public string ToDate
        {
            get { return strToDate; }
            set { strToDate = value; }

        }

        public string EmployeeId
        {
            get { return strEmployeeId; }
            set { strEmployeeId = value; }

        }

        public string DepartmentId
        {
            get { return strDepartmentId; }
            set { strDepartmentId = value; }

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

        public string CatagoryId
        {
            get { return strCatagoryId; }
            set { strCatagoryId = value; }

        }

        public string DesignationId
        {
            get { return strDesignationId; }
            set { strDesignationId = value; }
        }
        public string HeadOfficeId
        {
            get { return strHeadOfficeId; }
            set { strHeadOfficeId = value; }
        }

        public string BranchOfficeId
        {
            get { return strBranchOfficeId; }
            set { strBranchOfficeId = value; }
        }
                public string UpdateBy
        {
            get { return strUpdateBY; }
            set { strUpdateBY = value; }

        }
        public string Year
        {
            get { return strYear; }
            set { strYear = value; }
        }

        public string Month
        {
            get { return strMonth; }
            set { strMonth = value; }
        }
    }
}
