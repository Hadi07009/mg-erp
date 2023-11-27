using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
   public class AttendanceDashboardDTO
    {
        public string AttendanceDashBoardId { get; set; }
        public string LogDate { get; set; }
        public string Present { get; set; }
        public string DayOffOther { get; set; }
        public string OutDuty { get; set; }
        public string OutDutyOther { get; set; }
        public string Leave { get; set; }
        public string LeaveOther { get; set; }
        
        public string Resign { get; set; }
        public string ResignOther { get; set; }

        public string NightDuty { get; set; }
        public string NightDutyOther { get; set; }
        public string Recruitment { get; set; }
        public string UnrecognizedToMachine { get; set; }

        public string PhysicalPresent { get; set; }
        public string Punch { get; set; }
        public string PunchOther { get; set; }
        public string PunchOverall { get; set; }
        //public string PunchInvalid { get; set; }
        
        public string NoPunch { get; set; }
        public string NoPunchOther { get; set; }
        public string NoPunchOverall { get; set; }
        public string Accuracy { get; set; }

        public string Active { get; set; }
        public string ActiveOther { get; set; }

        public string StandByYn { get; set; }
        

        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }

        public string HeadOfficeId { get; set; }
        public string BranchOfficeId { get; set; }
    }
}
