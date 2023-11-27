using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class CaseInfoDTO
    {
        public string SerialNo { get; set; }
        public string CaseId { get; set; }
        public string CaseNo { get; set; }
        public string CaseTypeId { get; set; }
        public string CaseTypeName { get; set; }
        public string CaseStatus { get; set; }
        public string DefendantId { get; set; }
        public string Defendant { get; set; }
        public string ComplaintantId { get; set; }
        public string Complaintant { get; set; }
        public string IssueDate { get; set; }
        public string Amount { get; set; }
        public string CaseStatusId { get; set; }
        public string Remarks { get; set; }
        public string HearingId { get; set; }

        public string HearingDate { get; set; }
        public string HistoryDate { get; set; }
        
        public string Mode { get; set; }
        public string CHkSourseYn { get; set; }
        public string ChkAppearedYn { get; set; }
        public string SourseCaseId { get; set; }
        public string SourseCaseNo { get; set; }
        public string WarrantId { get; set; }
        public string Date { get; set; }
        public string FromDate { get; set; }
        public string Todate { get; set; }
        public string CourtId { get; set; }
        public string CourtName { get; set; }
        public string ActivityTypeId { get; set; }
        public string ActivityName { get; set; }
        public string CaseHistoryId { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }
        public string HeadOfficeId { get; set; }
        public string BranchOfficeId { get; set; }

    }
}
