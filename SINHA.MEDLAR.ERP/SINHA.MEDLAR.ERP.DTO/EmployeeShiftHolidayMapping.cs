using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
   public class EmployeeShiftHolidayMapping
    {
        public decimal SL { get; set; }
        public decimal MappingId { get; set; }

        public string CradNo { get; set; }
        public string EmployeeName { get; set; }
        public string DesignationName { get; set; }

        public string EmployeeId { get; set; }
        public decimal HolidayId { get; set; }
        public string HolidayName { get; set; }
        public string EffectDate { get; set; }
        public string ActiveYn { get; set; }
    }
}
