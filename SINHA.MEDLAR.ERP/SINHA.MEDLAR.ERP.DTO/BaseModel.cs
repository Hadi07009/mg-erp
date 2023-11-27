using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class BaseModel
    {
        public string HeadOfficeId { get; set; }
        public string BranchOfficeId { get; set; }
        public string LoggedInEmployeeId { get; set; }
    }
}
