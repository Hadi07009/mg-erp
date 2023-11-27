using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class ContactSheetDTO
    {
        private string strContactSheetId;
        private string strContactSheetName;

        private string strActvieYn;
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;

        public string ContactSheetId
        {
            get { return strContactSheetId;}
            set { strContactSheetId = value;} 

        }

        public string ContactSheetName
        {
            get { return strContactSheetName; }
            set { strContactSheetName = value; }

        }

        public string ActvieYn
        {
            get { return strActvieYn; }
            set { strActvieYn = value; }
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
