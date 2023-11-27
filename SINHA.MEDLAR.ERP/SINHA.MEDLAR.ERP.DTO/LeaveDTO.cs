using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class LeaveDTO
    {

        private string strLeaveId;
        private string strEmployeeId;
        private string strEmployeeName;
        private string strLeaveTypeId;
        private string strStartDate;
        private string strEndDate;
        private string strTotalLeave;
        private string strApprovedBy;
        private string strRemarks;
        private string strUpdateBy;
        private string strYear;
       
        private string strHeadOfficeId;
        private string strBranchOfficeId;

        private string strUnitId;
        private string strSectionId;
        
        public string SuspensionId { get; set; }
        public string CreateBy { get; set; }
        public string ConsumeYear { get; set; }
        public string LeaveYear { get; set; }
        public string FileName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public byte[] FileSize { get; set; }

        public string leave_start_date { get; set; }
        public string row_number { get; set; }
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
        public string Year
        {
            get { return strYear; }
            set { strYear = value; }
        }
        public string LeaveId
        {
            get { return strLeaveId; }
            set { strLeaveId = value ;} 
        }

        public string EmployeeId
        {
            get { return strEmployeeId; }
            set { strEmployeeId = value; }
        }

        public string EmployeeName
        {
            get { return strEmployeeName; }
            set { strEmployeeName = value; }
        }

        public string LeaveTypeId
        {
            get { return strLeaveTypeId; }
            set { strLeaveTypeId = value; }
        }

        public string StartDate
        {
            get { return strStartDate; }
            set { strStartDate = value; }
        }

        public string EndDate
        {
            get { return strEndDate; }
            set { strEndDate = value; }
        }

        public string TotalLeave
        {
            get { return strTotalLeave; }
            set { strTotalLeave = value; }
        }

        public string ApprovedBy
        {
            get { return strApprovedBy; }
            set { strApprovedBy = value; }
        }

        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }
        }

        public string UpdateBy
        {
            get { return strUpdateBy; }
            set { strUpdateBy = value; }
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
    }
}
