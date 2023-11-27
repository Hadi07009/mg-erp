using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class EmployeeShiftMapping
    {
        public decimal MappingId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DesignationName { get; set; }
        public string CardNo { get; set; }
        public decimal ShiftId { get; set; }
        public string ShiftName { get; set; }
        public string EffectDate { get; set; }
        //public DateTime shift_effect_date { get; set; }

        public DateTime roster_date { get; set; }

        public string roster_date_str { get; set; }


        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }
    }
}
