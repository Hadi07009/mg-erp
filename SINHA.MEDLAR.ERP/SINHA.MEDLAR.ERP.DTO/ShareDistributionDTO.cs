using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class ShareDistributionDTO
    {
        public string DistributionId { get; set; }
        public string CompanyId { get; set; }
        public string ShareHolderId { get; set; }
        public string NomineeId { get; set; }
        public string NoOfShare { get; set; }
        public string FaceValue { get; set; }
        public string PaidUpCapital { get; set; }
        public string SharePercent { get; set; }
        public string DisplayOrder { get; set; }
        public string UpdateBy { get; set; }
    }
}
