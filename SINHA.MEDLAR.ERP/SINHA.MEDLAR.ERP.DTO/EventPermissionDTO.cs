using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Web.UI;

namespace SINHA.MEDLAR.ERP.DTO
{
   public class EventPermissionDTO
    {
        public string EmployeeId { get; set; }


        public string Id { get; set; }
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string InterfaceId { get; set; }
        public string InterfaceName { get; set; }
        public string UIDisplayName { get; set; }
        public string SoftwareId { get; set; }
        public string ActiveYn { get; set; }
        public string MenuCode { get; set; }
        public string UICode { get; set; }

        public string MenuName { get; set; }
        public string UIName { get; set; }

        public string DisableSave { get; set; }
        public string DisableAdd { get; set; }
        public string DisableProcess { get; set; }
        public string DisableSearch { get; set; }
        public string DisableAtten { get; set; }
        public string DisaleDelete { get; set; }


        public string DisableSaveEventId { get; set; }
        public string DisableAddEventId { get; set; }
        public string DisableProcessEventId { get; set; }
        public string DisableSearchEventId { get; set; }
        public string DisableAttenEventId { get; set; }
        public string DisaleDeleteEventId { get; set; }
        public string DisableDeleteEventId { get; set; }

        //List<Control> controls = new List<Control>();

        public string MenuId { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }
        public string HeadOfficeId { get; set; }
        public string BranchOfficeId { get; set; }
    }
}
