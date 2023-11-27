using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class IfratTimeSheetDTO
    {
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public string SectionId { get; set; }
        public string SectionName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string LunchIn { get; set; }
        public string LunchOut { get; set; }
        public string IftarTime { get; set; }
        public string IftarStartTime { get; set; }
        public string IftarEndTime { get; set; }
        public string IftarHour { get; set; }
        public string IftarMinute { get; set; }
        public string UpdateBy { get; set; }
    }
}
